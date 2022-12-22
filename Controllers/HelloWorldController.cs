using Microsoft.AspNetCore.Mvc;

namespace APIS_con_.Net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{

    private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldService;
    TareasContext dbcontext;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger, TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando Hola Mundo");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createDb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}