using System;
using System.Collections.Generic;

#nullable disable

namespace CrudPeliculas_RazorPages_EntityFramework.Data
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
    }
}
