using task1.Models;

namespace task1.Repositories;

public interface IDepartmentRepository
{
    List<Department> GetAllWithStudents();

    Department GetByIdWithStudents(int id);
}