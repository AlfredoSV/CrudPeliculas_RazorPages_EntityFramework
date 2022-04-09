using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudPeliculas_RazorPages_EntityFramework.Data;
//using CrudPeliculas_RazorPages_EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CrudPeliculas_RazorPages_EntityFramework.Pages
{
    public class CrearPeliculaModel : PageModel
    {
        [BindProperty]
        public Pelicula Pelicula { get; set; }
        private readonly dbPeliculasContext _dbPeliculasContext;
        
        public CrearPeliculaModel(dbPeliculasContext pdbPeliculasContext)
        {
            
            _dbPeliculasContext = pdbPeliculasContext;

        }

        public IActionResult OnPostCrear()
        {
            _dbPeliculasContext.Peliculas.Add(Pelicula);
            _dbPeliculasContext.SaveChanges();
            return Redirect("/");
        }
    }
}
