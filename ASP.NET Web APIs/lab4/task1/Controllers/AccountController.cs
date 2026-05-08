using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using task1.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return NotFound();
        
        var roles = await _userManager.GetRolesAsync(user);
        
        if (roles.Contains("Admin"))
            return Ok("Admin profile");

        return Ok("Student profile");
    }

    [HttpPost("register/student")] 
    public async Task<IActionResult> RegisterStudent(RegisterDTO dto)
    {
        return await AddUser(dto, "Student");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin(RegisterDTO dto)
    {
        return await AddUser(dto, "Admin");
    }

    private async Task<IActionResult> AddUser(RegisterDTO dto, string role)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var user = new IdentityUser
        {
            UserName = dto.UserName,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return BadRequest("User creation failed");

        await _userManager.AddToRoleAsync(user, role);

        return Ok($"{role} registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.FindByNameAsync(dto.EmailOrUserName)
                   ?? await _userManager.FindByEmailAsync(dto.EmailOrUserName);

        if (user == null)
            return BadRequest("Invalid credentials");

        var result = await _userManager.CheckPasswordAsync(user, dto.Password);

        if (!result)
            return BadRequest("Invalid credentials");

        var token = await GenerateToken(user);

        return Ok(new { token });
    }

    private async Task<string> GenerateToken(IdentityUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName!)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var jwt = _configuration.GetSection("Jwt");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}