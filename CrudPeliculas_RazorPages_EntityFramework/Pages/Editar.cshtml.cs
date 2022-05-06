using CrudPeliculas_RazorPages_EntityFramework.Data;
using CrudPeliculas_RazorPages_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CrudPeliculas_RazorPages_EntityFramework.Pages.Shared
{
    public class EditarModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly dbPeliculasContext _dbPeliculasContext;

        [BindProperty]
        public ViewModelPelicula Pelicula { get; set; }

        public EditarModel(ILogger<IndexModel> logger, dbPeliculasContext pdbPeliculasContext)
        {
            _logger = logger;
            _dbPeliculasContext = pdbPeliculasContext;

        }
        public void OnGet(int? id)
        {
            var pel = _dbPeliculasContext.Peliculas.Single(p => p.Id == id);

            Pelicula = new ViewModelPelicula()
            {
                Duracion = pel.Duracion,
                Titulo = pel.Titulo
            ,
                Id = pel.Id
            };

        }

        public IActionResult OnPostEditar()
        {

            if (ModelState.IsValid)
            {
                var pelicula = _dbPeliculasContext.Peliculas.SingleOrDefault(p => p.Id == Pelicula.Id);

                pelicula.Titulo = Pelicula.Titulo;
                pelicula.Duracion = Pelicula.Duracion;

                _dbPeliculasContext.SaveChanges();

                return RedirectToPage("/Index");
                
                
            }

            return Page();

        }

    }
}
