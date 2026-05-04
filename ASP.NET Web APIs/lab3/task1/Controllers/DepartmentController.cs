
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using task1.Repositories;
using task1.Models;
using Mapster;
using task1.DTOs;
using task1.Mappers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentRepository _repo;

    public DepartmentController()
    {
        _repo = new DepartmentRepository();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var Departments = _repo.GetAllWithStudents();

        var result = Departments.AdaptTo();

        return Ok(result);
    }

    [HttpGet("id/{id}")]
    public IActionResult GetById(int id)
    {
        var Department = _repo.GetByIdWithStudents(id);
        if (Department == null)
        {
            return NotFound();
        }

        var result = Department.Adapt<DepartmentDTO>();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(DepartmentDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingDepartment = _repo.GetById(dto.Id);
        if (existingDepartment != null)
        {
            return BadRequest("Id already exists");
        }

        var department = dto.Adapt<Department>();

        _repo.Add(department);

        var result = department.Adapt<DepartmentDTO>();

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public IActionResult Update(DepartmentDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingDepartment = _repo.GetById(dto.Id);
        if (existingDepartment == null)
        {
            return NotFound("Id does not exist");
        }

        dto.Adapt<Department>();

        _repo.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingDepartment = _repo.GetById(id);

        if (existingDepartment == null)
        {
            return NotFound("Id does not exist");
        }

        _repo.Delete(existingDepartment);

        return NoContent();
    }

}