using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;
using System.Data.Entity;

namespace Vidly1.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        private ApplicationDbContext _context;
        public customerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.customers.ToList();
           return View();

        }

        public ActionResult details(int id)
        {
            var customers = (_context.customers).SingleOrDefault(x => x.id == id);
            if (customers == null)
                return HttpNotFound();

            return View(customers);

        }
    }
       
}