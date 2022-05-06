using CrudPeliculas_RazorPages_EntityFramework.Data;
using CrudPeliculas_RazorPages_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CrudPeliculas_RazorPages_EntityFramework.Pages.Shared
{
    public class NuevoModel : PageModel
    {
        private readonly dbPeliculasContext _dbPeliculasContext;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public ViewModelPelicula Pelicula { get; set; }

        public NuevoModel(ILogger<IndexModel> logger, dbPeliculasContext pdbPeliculasContext)
        {
            _logger = logger;
            _dbPeliculasContext = pdbPeliculasContext;

        }
        public void OnGet()
        {
        }

        public IActionResult OnPostCrear()
        {

            if (ModelState.IsValid)
            {
                var pelicula = new Pelicula() { Titulo = Pelicula.Titulo, Duracion = Pelicula.Duracion };
                _dbPeliculasContext.Peliculas.Add(pelicula);
                _dbPeliculasContext.SaveChanges();
                return RedirectToPage("/Index");
            }

            return Page();
        }


    }
}
