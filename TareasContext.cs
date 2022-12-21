using Microsoft.EntityFrameworkCore;
using APIS_con_.Net.Models;

namespace APIS_con_.Net;

public class TareasContext : DbContext {
    public DbSet<Categoria> Categorias{get; set;}
    public DbSet<Tarea> Tareas {get; set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){} 

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5539bde1-583e-4a98-af03-09fd3c212af1"), Nombre = "Actividades pendientes", Peso = 20});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5539bde1-583e-4a98-af03-09fd3c212a02"), Nombre = "Actividades personales", Peso = 50});

        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);

        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("5539bde1-583e-4a98-af03-09fd3c212a10"), CategoriaId = Guid.Parse("5539bde1-583e-4a98-af03-09fd3c212af1"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("5539bde1-583e-4a98-af03-09fd3c212a11"), CategoriaId = Guid.Parse("5539bde1-583e-4a98-af03-09fd3c212a02"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver Series", FechaCreacion = DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.Property(p => p.Comentario).IsRequired(false);
            tarea.HasData(tareasInit);
        });
    }
}