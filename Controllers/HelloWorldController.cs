using Microsoft.AspNetCore.Mvc;

namespace APIS_con_.Net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{

    private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando Hola Mundo");
        return Ok(helloWorldService.GetHelloWorld());
    }
}