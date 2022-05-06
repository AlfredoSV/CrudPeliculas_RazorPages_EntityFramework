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
        public List<Pelicula> Peliculas = new List<Pelicula>();
        private readonly dbPeliculasContext _dbPeliculasContext;

        [BindProperty]
        public ViewModelPelicula Pelicula { get; set; }


        public const int TAMANIO_PAGINA = 5;
        public const int TAMANIO_MAXIMO_RANGO = 3;
        public int Pagina_Actual = 1;
        public int Total_Paginas;
        public bool Siguiente = false;
        public bool Anterior = false;
        public bool HayRegistros = false;
        public int Min_Bloque = 1;
        public int Max_Bloque = 3;
        public int Bloques_De_Paginas;
        public int Bloque_Actual = 1;
        public const int TAMANIO_BLOQUES = 3;


        public IndexModel(ILogger<IndexModel> logger, dbPeliculasContext pdbPeliculasContext)
        {
            _logger = logger;
            _dbPeliculasContext = pdbPeliculasContext;

        }

        public void OnGet(int pagina = 1)
        {

            ConsultarPeliculas(pagina);

        }
  

     
        public void OnGetElimiar(int? id)
        {
            var pelicula = _dbPeliculasContext.Peliculas.FirstOrDefault(p => p.Id == id);
            _dbPeliculasContext.Peliculas.Remove(pelicula);
            _dbPeliculasContext.SaveChanges();

            ConsultarPeliculas();


        }

        private void ConsultarPeliculas(int pagina = 1)
        {
            Peliculas = _dbPeliculasContext.Peliculas.ToList();

            Total_Paginas = (int)Math.Ceiling(((decimal)Peliculas.Count / (decimal)TAMANIO_PAGINA));

            if (Total_Paginas == 0)
            {
                Siguiente = false;
                Anterior = false;
                HayRegistros = false;
            }
            else
            {
                Pagina_Actual = pagina;
                HayRegistros = true;


                if (Pagina_Actual == 1 && Total_Paginas > 1)
                {
                    Anterior = false;
                    Siguiente = true;
                }
                else if (Pagina_Actual == 1 && Total_Paginas > 1)
                {
                    Anterior = false;
                    Siguiente = true;
                }
                else if (Total_Paginas == 1)
                {
                    Anterior = false;
                    Siguiente = false;
                }
                else if (Pagina_Actual == Total_Paginas && Total_Paginas > 1)
                {
                    Anterior = true;
                    Siguiente = false;

                }
                else
                {
                    Anterior = true;
                    Siguiente = true;

                }

                Peliculas = Peliculas.Skip((pagina - 1) * TAMANIO_PAGINA).Take(TAMANIO_PAGINA).ToList();
                
                Bloques_De_Paginas = (int)Math.Ceiling((decimal)Total_Paginas / (decimal)TAMANIO_BLOQUES);
                Bloque_Actual = ((decimal)Pagina_Actual) / (decimal)(Bloque_Actual * TAMANIO_BLOQUES) <= 1 ? Bloque_Actual : (Bloque_Actual += 1);
                Min_Bloque = Bloque_Actual * TAMANIO_BLOQUES - 2;
                Max_Bloque = Bloque_Actual * TAMANIO_BLOQUES;
            }

        }
    }
}
