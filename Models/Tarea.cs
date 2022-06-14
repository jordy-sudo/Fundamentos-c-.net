using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoef.Models
{
    public class Tarea
    {
        [Key]
         public Guid TareaId{get;set;}
         [ForeignKey("CategoriaId")]
         public Guid CategoriaId{get;set;}
         [Required]
         [MaxLength(250)]
         public string Titulo{get;set;}
         public string Descripcion{get;set;}
         //prioridad y relaciones
         public Prioridad PrioridadTarea{get;set;}
         public DateTime FechaCreacion{get;set;}
         //propiedad virtual
         public virtual Categoria Categoria {get;set;}
         //propiedad q no se crea dentro de la BD
         [NotMapped]
         public string Resumen{get;set;}
         
    }
    public enum Prioridad{
        Baja,
        Media,
        Alta
    }
}
