using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private IEnumerable<Movie> getMovies()
        {
            IEnumerable<Movie> movies = _context.Movie.Include(m => m.Genre);

            return movies;
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek"};

            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer 1"},
                new Customer {Id = 2, Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            
        }
        
        [Route("released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" +month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }


        public ActionResult Index()
        {
            IEnumerable<Movie> movies = getMovies();

            var viewModel = new MoviesViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            IEnumerable<Movie> movies = getMovies();

            //Alternate predicate using lambda delegate

            /*
             * Movie matchedMovie = movies.SingleOrDefault(movie => movie.Id == id);
             *
             */

            Predicate<Movie> findMovie = delegate (Movie m) { return m.Id == id; };
            
            Movie matchedMovie = movies.ToList().Find(findMovie); //.SingleOrDefault(findMovie);
            //Movie matchedMovie = movies.Find(findMovie);

            return View(matchedMovie);
        }

    }
}