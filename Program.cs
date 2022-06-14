using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using proyectoef;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);

//configuracion de entity base de datos en memoria 
//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//mapeo 
app.MapGet("/dbConexion", async([FromServices] TareasContext dbContext)=>{
    //verfiico q la base se puede crear
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});
//mapeo para muestra de datos
app.MapGet("/Tareas", async([FromServices] TareasContext dbContext)=>{
    //verfiico q la base se puede crear
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));//todos los datos
});
app.MapGet("/Tareas/filtro", async([FromServices] TareasContext dbContext)=>{
    //verfiico q la base se puede crear
    //los datos pero filtrados
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria).Where(p=>p.PrioridadTarea==proyectoef.Models.Prioridad.Media));
});
//metodo post para la base de datos
app.MapPost("/Tareas", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>{
   //creo una instancia de Tarea para enviarla
   tarea.TareaId=Guid.NewGuid();//creo un ID 
   tarea.FechaCreacion=DateTime.Now;
   await dbContext.AddAsync(tarea);
   //otra manera
   //await dbContext.Tareas.AddAsync(tarea);
   //guardo los datos en la base -.- 
    await dbContext.SaveChangesAsync();
   return Results.Ok("Tarea creada");
});
//metodo put
app.MapPut("/Tareas/{id}", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid id)=>{
  //capturo el objeto con el id 
  var  tareaACtual = dbContext.Tareas.Find(id);
  if(tareaACtual!=null){
    tareaACtual.CategoriaId=tarea.CategoriaId;
    tareaACtual.Titulo=tarea.Titulo;
    tareaACtual.PrioridadTarea=tarea.PrioridadTarea;
    tareaACtual.Descripcion=tarea.Descripcion;
    await dbContext.SaveChangesAsync();
    return Results.Ok("Tarea actualizada");
  }  
  return Results.NotFound("error al actualizar");
});
//eliminar datos
app.MapDelete("/delete/{id}",async([FromServices] TareasContext dbContext,[FromRoute]Guid id)=>{
    var  tareaACtual = dbContext.Tareas.Find(id);
    if(tareaACtual!=null){
        dbContext.Remove(tareaACtual);
        await dbContext.SaveChangesAsync();
        return Results.Ok("Tarea eliminada");
    }
    return Results.NotFound("Error al eliminar");
});
app.Run();
