using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task1.Validations;

namespace task1.DTOs;

public class DepartmentGetAllDTO
{
    public string Department { get; set; }
    public List<string> Students { get; set; }
    public int Count { get; set; }
    public string Msg { get; set; }
}