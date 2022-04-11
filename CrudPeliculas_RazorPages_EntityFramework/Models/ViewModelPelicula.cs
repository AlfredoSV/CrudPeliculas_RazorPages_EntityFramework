using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudPeliculas_RazorPages_EntityFramework.Models
{
    public class ViewModelPelicula
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo titulo es requerido")]
        public string Titulo { get; set; }

        [Range(1,190,ErrorMessage = "El campo duración es invalido")]
        [Required(ErrorMessage = "El campo duración es requerido")]
        public int? Duracion { get; set; }
    }
}
