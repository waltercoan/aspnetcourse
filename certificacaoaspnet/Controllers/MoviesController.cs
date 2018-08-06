using certificacaoaspnet.DAL;
using certificacaoaspnet.Models;
using System.Data.Entity;
using certificacaoaspnet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace certificacaoaspnet.Controllers
{
    
    public class MoviesController : Controller
    {
        private CertificacaoDbContext _context;

        public MoviesController()
        {
            _context = new CertificacaoDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        /*List<Movie> movies = new List<Movie>
        {
            new Movie {Id = 1, Name= "Shrek!" },
            new Movie {Id = 2, Name= "Wall-e!" },
        };*/


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            

            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = new Movie()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                if (movie.Genre != null)
                    movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound("Deu ruim");

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies
        [OutputCache(Duration =50,Location = OutputCacheLocation.Server)]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            //var movies = _context.Movies.Include(m=>m.Genre).ToList();

            //return View(movies);
            return View();
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound("Deu ruim");

            return View(movie);
        }
        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        [Route("movies/released/{year}/{month:regex(\\d{2}):min(1):max(12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //ASP.NET MVC Attribute Route Constraints
        //[Route("movies/released/{name:minlength(3):maxlength(10)}")]
        //[Route("movies/released/{name:minlength(3):maxlength(10):int}")]
        //[Route("movies/released/{name:minlength(1):maxlength(10):float}")]
        //[Route("movies/released/{name:minlength(1):maxlength(10):guid}")]
        [Route("movies/released/{name:minlength(1):maxlength(10)}")]
        public ActionResult ByName(String name)
        {
            return Content(name);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek !" };
            ViewData["Movie"] = movie;
            ViewBag.Movie = movie;

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"},
            };

            /*var viewResult = new ViewResult();
            viewResult.ViewData.Model <- ViewDataDictionary*/

            var viewModel = new RandomMovieViewModel
            { Customers = customers,
              Movie = movie
            };


            return View(viewModel);
        }

    }
}