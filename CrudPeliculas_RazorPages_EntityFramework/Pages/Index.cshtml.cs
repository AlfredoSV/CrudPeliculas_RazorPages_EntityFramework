using CrudPeliculas_RazorPages_EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPeliculas_RazorPages_EntityFramework.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Pelicula> peliculas;
        private readonly dbPeliculasContext _dbPeliculasContext;
        public IndexModel(ILogger<IndexModel> logger, dbPeliculasContext pdbPeliculasContext)
        {
            _logger = logger;
            _dbPeliculasContext = pdbPeliculasContext;


        }

        public void OnGet()
        {

            peliculas = _dbPeliculasContext.Peliculas.ToList();

        }
    }
}
