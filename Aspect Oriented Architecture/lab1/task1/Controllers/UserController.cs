using Microsoft.AspNetCore.Mvc;
using task1.Interfaces;

namespace task1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public string Get(int id)
    {
        return _userService.GetUser(id);
    }
}
