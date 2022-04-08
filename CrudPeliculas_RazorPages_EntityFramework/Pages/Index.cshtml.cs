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
        private readonly DbPeliculasContext _dbPeliculasContext;
        public IndexModel(ILogger<IndexModel> logger, DbPeliculasContext dbPeliculasContext)
        {
            _logger = logger;
            _dbPeliculasContext = dbPeliculasContext;


        }

        public void OnGet()
        {

            peliculas = _dbPeliculasContext.Peliculas.ToList();

        }
    }
}
