using Microsoft.AspNetCore.Mvc;
using task1.Filters;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }

    [HttpGet("error")]
    [ExceptionFilter]
    public IActionResult Error()
    {
        throw new Exception("Db exception");
    }

    [HttpGet("ok")]
    [ResultFilter]
    public IActionResult OK()
    {
        return Ok();
    }
}