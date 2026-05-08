using task1.Models;

namespace task1.Repositories;

public interface IStudentRepository : IGenericRepository<Student>
{
    List<Student> GetAllWithDepartment();

    Student GetByIdWithDepartment(int id);

    List<Student> GetByNameWithDepartment(string name);
}