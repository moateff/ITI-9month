using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public List<Student> GetAllWithDepartment()
    {
        return _dbSet.Include(s => s.Department).AsNoTracking().ToList();
    }

    public Student GetByIdWithDepartment(int id)
    {
        return _dbSet.Include(s => s.Department).AsNoTracking().FirstOrDefault(s => s.SSN == id);
    }

    public List<Student> GetByNameWithDepartment(string name)
    {
        return _dbSet.Include(s => s.Department).Where(s => s.Name == name).AsNoTracking().ToList();
    }
}