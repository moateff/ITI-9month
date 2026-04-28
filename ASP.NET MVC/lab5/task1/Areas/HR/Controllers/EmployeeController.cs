using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace task1.Controllers
{
    [Area("HR")]
    public class EmployeeController : Controller
    {
        HRDbContext Context = new HRDbContext();

        // GET: EmployeeController
        public ActionResult Index()
        {
            ViewBag.depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name");
            return View(Context.Employees.Include(e => e.Dept).ToList());
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            var selectedEmployees = new List<Employee>();

            if (!int.TryParse(collection["dept"], out int selectedDeptId)) 
            {
                selectedEmployees = Context.Employees
                    .Include(e => e.Dept)
                    .ToList();
            }
            else
            {
                selectedEmployees = Context.Employees
                    .Include(e => e.Dept)
                    .Where(e => e.DeptID == selectedDeptId)
                    .ToList();
            }

            ViewBag.depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name", selectedDeptId);

            return View(selectedEmployees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var emp = Context.Employees
                .Include(e => e.Dept)
                .FirstOrDefault(e => e.EmpID == id);

            if (emp == null) return NotFound();

            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = Context.Departments.ToList();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (emp != null)
            {
                Context.Employees.Add(emp);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.DeptID = Context.Departments.ToList();
                return View(emp);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DeptID = Context.Departments.ToList();

            var emp = Context.Employees
                .Include(e => e.Dept)
                .FirstOrDefault(e => e.EmpID == id);

            if (emp == null) return NotFound();

            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            var editedEmp = Context.Employees.FirstOrDefault(e => e.EmpID == emp.EmpID);

            if (editedEmp != null)
            {
                editedEmp.Name = emp.Name;
                editedEmp.Password = emp.Password;
                editedEmp.Salary = emp.Salary;
                editedEmp.joinDate = emp.joinDate;
                editedEmp.Email = emp.Email;
                editedEmp.PhoneNum = emp.PhoneNum;
                editedEmp.DeptID = emp.DeptID;

                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.DeptID = Context.Departments.ToList();
                return View(emp);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = Context.Employees
                .Include(e => e.Dept)
                .FirstOrDefault(e => e.EmpID == id);

            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            if (emp != null)
            {
                var empToDelete = Context.Employees
                    .FirstOrDefault(e => e.EmpID == emp.EmpID);

                if (empToDelete != null)
                {
                    Context.Employees.Remove(empToDelete);
                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(emp);
                }
            }
            else
            {
                return View(emp);
            }
        }
    }
}