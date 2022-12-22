using Microsoft.AspNetCore.Mvc;
using APIS_con_.Net.Models;
using APIS_con_.Net.services;

namespace APIS_con_.Net.Controllers;

//[ApiController]
[Route("api/[controller]")]

public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;
    public CategoriaController(ICategoriaService categoria)
    {
        categoriaService = categoria;
    }
    
    [HttpGet]
    //[Route("Get/GetCategoria")]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Delete(id, categoria);
        return Ok();
    }
}