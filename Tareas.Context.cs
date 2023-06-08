using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Tarea>? Tareas { get; set; }

        // DbSer<Modelo>
        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriaInit = new List<Categoria>();
            categoriaInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("98c49e77-37f5-4b88-86c0-6e5a797ffe28"),
                Nombre = "Actividades pendientes",
                Peso = 12
            });

            categoriaInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("98c49e77-37f5-4b88-86c0-6e5a797ffe30"),
                Nombre = "Aprender Angular",
                Peso = 20
            });

            List<Tarea> tarasInit = new List<Tarea>();
            tarasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("98c49e77-37f5-4b88-86c0-6e5a797ffe10"),
                CategoriaId = Guid.Parse("98c49e77-37f5-4b88-86c0-6e5a797ffe28"),
                Titulo = "Primeras Tareas",
                PrioridadTarea = Prioridad.Alta,
                FechaCreacion = DateTime.Now,
            });

            tarasInit.Add(new Tarea()
            {
                TareaId = Guid.Parse("98c49e77-37f5-4b88-86c0-6e5a797ffe11"),
                CategoriaId = Guid.Parse("98c49e77-37f5-4b88-86c0-6e5a797ffe30"),
                Titulo = "Programacion",
                PrioridadTarea = Prioridad.Baja,
                FechaCreacion = DateTime.Now,
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(cat => cat.CategoriaId);
                categoria.Property(cat => cat.Nombre).IsRequired().HasMaxLength(50);
                categoria.Property(cat => cat.Description).IsRequired(required: false);
                categoria.Property(cat => cat.Peso);

                categoria.HasData(categoriaInit);
            });

            modelBuilder.Entity<Tarea>(tarea =>
            { 
                tarea.ToTable("Tarea");
                tarea.HasKey(ta => ta.TareaId);
                tarea.HasOne(ta => ta.Categoria).WithMany(cat => cat.Tareas).HasForeignKey(ta => ta.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);

                tarea.Property(p => p.Description).IsRequired(required: false);

                tarea.Property(p => p.PrioridadTarea);

                tarea.Property(p => p.FechaCreacion);
                tarea.Ignore(p => p.Resumen);

                tarea.HasData(tarasInit);
            });
        }
    }

}