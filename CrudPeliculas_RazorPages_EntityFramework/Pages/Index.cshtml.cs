using CrudPeliculas_RazorPages_EntityFramework.Data;
using CrudPeliculas_RazorPages_EntityFramework.Models;
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
        public List<Pelicula> peliculas = new List<Pelicula>();
        [BindProperty]
        public ViewModelPelicula Pelicula { get; set; }

        private readonly dbPeliculasContext _dbPeliculasContext;
        public IndexModel(ILogger<IndexModel> logger, dbPeliculasContext pdbPeliculasContext)
        {
            _logger = logger;
            _dbPeliculasContext = pdbPeliculasContext;


        }

        public void OnGet()
        {

            peliculas = _dbPeliculasContext.Peliculas.ToList();
            ViewData["Accion"] = "Listar";

        }
        public void OnGetEditar(int? id)
        {

            var pel = _dbPeliculasContext.Peliculas.Single(p => p.Id == id);

            Pelicula = new ViewModelPelicula() { Duracion = pel.Duracion,
            Titulo = pel.Titulo
            ,Id = pel.Id };

        }

        public void OnGetNuevo()
        {

            ViewData["Accion"] = "Nuevo";

        }

        public void OnPostCrear()
        {

            if (ModelState.IsValid)
            {
                var pelicula = new Pelicula() { Titulo = Pelicula.Titulo, Duracion = Pelicula.Duracion };
                _dbPeliculasContext.Peliculas.Add(pelicula);
                _dbPeliculasContext.SaveChanges();
                peliculas = _dbPeliculasContext.Peliculas.ToList();
                ViewData["Accion"] = "Listar";
            }
            else
            {

                ViewData["Accion"] = "Nuevo";
            }
            

        }
    }
}
