using Microsoft.AspNetCore.Mvc;
using APIS_con_.Net.Models;
using APIS_con_.Net.services;

namespace APIS_con_.Net.Controllers;

[Route("api/[controller]")]

public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController(ITareaService tarea)
    {
        tareaService = tarea;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tarea.TareaId = Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;
        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Delete(id, tarea);
        return Ok();
    }
}