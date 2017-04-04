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
        // GET: Movies/random
        public ActionResult random()
        {
            var movie = new Movie() { Name = "SHARK!" };
            return View(movie);
        }
        [Route("Movies/customers")]
        public ActionResult customers()
        {
            var customer1 = new customer() { name = "naveen" };
            var customer2 = new customer() { name = "naga" };


            return View();
        }
    }
}