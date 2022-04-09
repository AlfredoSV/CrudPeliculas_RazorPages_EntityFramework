using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CrudPeliculas_RazorPages_EntityFramework.Data
{
    public partial class Pelicula
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
    }
}
