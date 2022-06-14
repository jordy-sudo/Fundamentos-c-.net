using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria>Categorias{get;set;}
        public DbSet<Tarea>Tareas{get;set;}
        public TareasContext(DbContextOptions<TareasContext>options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             //creacion de una lista para enviarla en la migracion y creacion de datos
            List<Categoria> CategoriasInit = new List<Categoria>();
            //aqui ya puedo acceder a la lista refernciada
            CategoriasInit.Add(new Categoria(){
                CategoriaId=Guid.Parse("69d20de1-4182-4ce6-98d5-a73d2a50511a"),
                Nombre="Actividades en Espera",
                Descripcion="Son actividades que necesitan ser terminadas",
                Peso=30
            });
            //segunda instancia del list
              CategoriasInit.Add(new Categoria(){
                CategoriaId=Guid.Parse("69d20de1-4182-4ce6-98d5-a73d2a505120"),
                Nombre="Actividades terminadas",
                Descripcion="Son actividades que estan terminadas",
                Peso=20
            });
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

                categoria.Property(p => p.Descripcion);
                
                categoria.Property(p=> p.Peso);
                //envio los valores de la lista a la base de datos 
                categoria.HasData(CategoriasInit);
            });
            //creo el list para agragar a la tabla tareas
            List<Tarea> TareasInit= new List<Tarea>();
            TareasInit.Add(new Tarea(){
                TareaId=Guid.Parse("69d20de1-4182-4ce6-98d5-a73d2a505110"),
                CategoriaId=Guid.Parse("69d20de1-4182-4ce6-98d5-a73d2a50511a"),
                Titulo="Terminar curso de platzi en c#",
                Descripcion="Terminar toda la escuela de C# en platzi hasta fin de mes",
                PrioridadTarea=Prioridad.Alta,
                FechaCreacion=DateTime.Now

            });
            TareasInit.Add(new Tarea(){
                TareaId=Guid.Parse("69d20de1-4182-4ce6-98d5-a73d2a505130"),
                CategoriaId=Guid.Parse("69d20de1-4182-4ce6-98d5-a73d2a505120"),
                Titulo="Terminar CV de programador",
                Descripcion="Ingresar los certificados obtenidos en platzi al CV",
                PrioridadTarea=Prioridad.Media,
                FechaCreacion=DateTime.Now

            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);

                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);

                tarea.Property(p => p.Descripcion).IsRequired(false);//esto para q no sea requerido

                tarea.Property(p => p.PrioridadTarea);

                tarea.Property(p => p.FechaCreacion);

                tarea.Ignore(p => p.Resumen);
                //envio la list a la base de datos
                tarea.HasData(TareasInit);

            });

        }
    }
}