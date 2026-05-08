using task1.Models;

namespace task1.Repositories;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    List<Department> GetAllWithStudents();

    Department GetByIdWithStudents(int id);
}