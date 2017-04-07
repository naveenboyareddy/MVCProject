using System.Linq;
using System.Web.Mvc;
using Vidly1.Models;
using Vidly1.ViewModels;
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
       
        public ActionResult New()
        {
            var membershiptypes = _context.membershiptypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                Membershiptypes = membershiptypes
            };


            return View("Customerform", viewmodel);
        }
        [HttpPost]
        public ActionResult Save(customer customer)
        {
            if (customer.id == 0)
                _context.customers.Add(customer);

            else
            {
          
                var customerInDb = _context.customers.Single( c=> c.id == customer.id);
                customerInDb.name = customer.name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "customer");
        }
        public ViewResult Index()
        {
            var customers = _context.customers.Include(c => c.MembershipType).ToList();
           return View(customers);

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();

            var viewmodel = new CustomerFormViewModel
            {
                customer = customer,
              Membershiptypes = _context.membershiptypes.ToList()
            };

            return View("Customerform", viewmodel);
        }

        public ActionResult details(int id)
        {
            var customers = (_context.customers).Include(C => C.MembershipType).SingleOrDefault(x => x.id == id);
          
            if (customers == null)
                return HttpNotFound();

            return View(customers);

        }
    }
       
}