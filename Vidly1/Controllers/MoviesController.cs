using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Vidly1.Migrations;
using Vidly1.Models;
using Vidly1.ViewModels;


namespace Vidly1.Controllers
{
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
        public ActionResult New()
        {
            var genres = _context.genres.ToList();
            var viewmodel = new MovieFormViewModel
            {
                genres = genres
            };
            return View("MovieForm", viewmodel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewmodel = new MovieFormViewModel
            {
                movies = movie,
                genres = _context.genres.ToList()
            };
            return View("MovieForm", viewmodel);
        }
          [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
              
                _context.movies.Add(movie);
            }
            else
            {
                var movieindb = _context.movies.Single(c => c.Id == movie.Id);

                movieindb.Name = movie.Name;
                movieindb.ReleaseDate = movie.ReleaseDate;
                movieindb.GenreId = movie.GenreId;
                //movieindb.NumbersInStock = movie.NumbersInStock;
            }
           
                _context.SaveChanges();
            
            
            return RedirectToAction("Index", "Movies");
        }
        public ViewResult Index()
        {
            var movies = _context.movies.Include(c => c.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = (_context.movies).Include(c => c.Genre).SingleOrDefault(x => x.Id == id);
            if (movie == null)

                return HttpNotFound();

            return View(movie);

        }
    }
}