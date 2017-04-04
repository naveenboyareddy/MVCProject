using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {


        public ViewResult index()
        {
            var movies = getmovies();
            return View(movies);
        }
        private IEnumerable<Movie> getmovies()
        {
            return new List<Movie>
            {
                new Movie{ Id = 1, Name = "SHARK!" },
                new Movie{ Id = 2, Name = "HUSH"}
           
        };
        }
       
    }
}