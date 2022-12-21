using Microsoft.AspNetCore.Mvc;

namespace APIS_con_.Net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(ListWeatherForecast == null || !ListWeatherForecast.Any()) {

            ListWeatherForecast =  Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();

        }

    }

    [HttpGet(Name = "GetWeatherForecast")]
    //[Route("Get/weatherforecast")]
    //[Route("Get/weatherforecast1")]
    //[Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    { 
        _logger.LogDebug("Retornando la lista de Weatherforecast");
        return ListWeatherForecast;
    }

    [HttpPost]
    [Route("Post/weatherforecastAdd")]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        try {

            ListWeatherForecast.Add(weatherForecast);

        }catch(Exception ex) {
            return Ok("Ha ocurrido un error: " + ex);
        }
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        try {

            ListWeatherForecast.RemoveAt(index);
        
        }catch(Exception ex){
            return Ok("El indice proporcionado no existe en la lista, " + ex.Message);
        }

        return Ok("Registro eliminado con éxito!!!");
    }
}
