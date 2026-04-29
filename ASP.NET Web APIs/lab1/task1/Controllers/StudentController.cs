
using Microsoft.AspNetCore.Mvc;
using task1.Context;
using task1.Models;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentController()
    {
        _context = new AppDbContext();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _context.Students.ToList();
        return Ok(students);
    }

    [HttpGet("id/{id}")]
    public IActionResult GetById(int id)
    {
        var student = _context.Students.Find(id);

        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        var students = _context.Students.Where(s => s.Name == name).ToList();

        if (students.Count == 0)
        {
            return NotFound();
        }

        return Ok(students);
    }

    [HttpPost]
    public IActionResult Add(Student student)
    {
        student.SSN = 0;

        _context.Students.Add(student);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = student.SSN }, student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        if (id != student.SSN)
        {
            return BadRequest("Id mismatch");
        }

        var existingStudent = _context.Students.Find(id);

        if (existingStudent == null)
        {
            return NotFound();
        }

        // Safe update (avoids tracking issues)
        _context.Entry(existingStudent).CurrentValues.SetValues(student);

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);

        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        _context.SaveChanges();

        return NoContent();
    }

}