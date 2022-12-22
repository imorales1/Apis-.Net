using APIS_con_.Net.Models;

namespace APIS_con_.Net.services;

public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas.OrderByDescending(x => x.FechaCreacion);
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        
        if(tareaActual != null)
        {
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id, Tarea tarea);
}