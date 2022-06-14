using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace proyectoef.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Peso {get;set;}
        //propiedad virtual
        //para que no se cree un ciclo infinito
        [JsonIgnore]
        public virtual ICollection <Tarea> Tareas{get;set;}
    }
}