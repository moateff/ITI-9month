using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RoleController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public RoleController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task<IActionResult> Add(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Role name is required");

        if (await _roleManager.RoleExistsAsync(name))
            return BadRequest("Role already exists");

        var result = await _roleManager.CreateAsync(new IdentityRole(name));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("Role created");
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        var role = await _roleManager.FindByNameAsync(name);

        if (role == null)
            return NotFound("Role not found");

        var result = await _roleManager.DeleteAsync(role);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("Role deleted");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var roles = await _roleManager.Roles
            .Select(r => r.Name)
            .ToListAsync();

        return Ok(roles);
    }
}