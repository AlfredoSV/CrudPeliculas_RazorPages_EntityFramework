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
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            using (var db = new dbPeliculasContext())
            {
                peliculas = db.Peliculas.ToList();
            }
            
        }

        public void OnGet()
        {

        }
    }
}
