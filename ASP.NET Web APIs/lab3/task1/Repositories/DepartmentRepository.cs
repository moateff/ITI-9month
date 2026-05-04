using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public List<Department> GetAllWithStudents()
    {
        return _dbSet.Include(s => s.Students).ToList();
    }

    public Department GetByIdWithStudents(int id)
    {
        return _dbSet.Include(s => s.Students).FirstOrDefault(s => s.Id == id);
    }
}