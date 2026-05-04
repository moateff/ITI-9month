using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using task1.Repositories;
using task1.Models;
using Mapster;
using task1.DTOs;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentRepository _repo; 

    public StudentController()
    {
        _repo = new StudentRepository();
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _repo.GetAllWithDepartment();

        var result = students.Adapt<List<StudentDTO>>();

        return Ok(result);
    }

    [HttpGet("id/{id}")]
    public IActionResult GetById(int id)
    {
        var student = _repo.GetByIdWithDepartment(id);
        if (student == null)
        {
            return NotFound();
        }

        var result = student.Adapt<StudentDTO>();

        return Ok(result);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        var students = _repo.GetByNameWithDepartment(name);

        if (students.Count == 0)
        {
            return NotFound();
        }

        var result = students.Adapt<List<StudentDTO>>();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(StudentDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingStudent = _repo.GetById(dto.SSN);
        if (existingStudent != null)
        {
            return BadRequest("Id already exists");
        }

        var student = dto.Adapt<Student>();

        _repo.Add(student);

        var result = student.Adapt<StudentDTO>();

        return CreatedAtAction(nameof(GetById), new { id = result.SSN }, result);
    }

    [HttpPut]
    public IActionResult Update(StudentDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingStudent = _repo.GetById(dto.SSN);
        if (existingStudent == null)
        {
            return NotFound("Id does not exist");
        }

        dto.Adapt<Student>();

        _repo.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingStudent = _repo.GetById(id);

        if (existingStudent == null)
        {
            return NotFound("Id does not exist");
        }

        _repo.Delete(existingStudent);

        return NoContent();
    }

}