using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;

namespace Vidly1.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        public ViewResult Index()
        {
            var customers = getallcustomers();
            return View(customers);
        }

        public ActionResult details(int id)
        {
            var customers = getallcustomers().SingleOrDefault(x => x.id == id);
            if(customers == null)
            return HttpNotFound();

            return View(customers);

        }
        private IEnumerable<customer> getallcustomers()
        {
             return new List<customer>
            {
               new customer { id = 101, name ="Naveen"},
               new customer { id = 102, name = "Naga"}
            };
        }
    }
}