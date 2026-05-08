using task1.DTOs;
using task1.Models;

namespace task1.Mappers;

public static class MapperExtentions
{
    public static List<DepartmentGetAllDTO> AdaptTo(this List<Department> departments)
    {
        var dtos = new List<DepartmentGetAllDTO>();

        foreach (var item in departments)
        {
            var students = new List<string>();

            foreach (var student in item.Students)
            {
                students.Add(student.Name);
            }

            dtos.Add(new DepartmentGetAllDTO
            {
                Department = item.Name,
                Students = students,
                Count = item.Students.Count,
                Msg = item.Students.Count > 0 ? 
                            "There are students in this department" : 
                            "There are no students in this department"
            });
        }

        return dtos;
    }
}