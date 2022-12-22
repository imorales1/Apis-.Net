using APIS_con_.Net.Models;
namespace APIS_con_.Net.services;

public class CategoriaService : ICategoriaService
{
    TareasContext context; 

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Categoria> Get() 
    {
        return context.Categorias;
    }

    /*public void Save(Categoria categoria)
    {
        context.Add(categoria);
        context.SaveChanges();
    }*/

    //Si quisieramos que el método sea asincrono debemos hacer lo siguiente
    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }

    }

    public async Task Delete(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }

    }
    
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id, Categoria categoria);
} 
