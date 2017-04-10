using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly1.Models;

namespace Vidly1.Controllers.Api
{
    public class CustomersController : ApiController
    {


        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get/Api/Customers

        public IEnumerable<customer> GetCustomers()
        {
            return _context.customers.ToList();
 
        }
        // Get / Api / Customers / 1
        public customer GetCustomer(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.id == id);
           
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
         
        // Post / Api / Customers
        [HttpPost]
        public customer CreateCustomer(customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.customers.Add(customer);

            return customer;

        }

        // Put / Api/ Customers /1
        [HttpPut]
        public void UpdateCustomer(int id, customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerInDb = _context.customers.SingleOrDefault(c => c.id == id);

            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            CustomerInDb.name = customer.name;
            CustomerInDb.BirthDate = customer.BirthDate;
            CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
            CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();
        }

        // Delete / Api/ Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDb = _context.customers.SingleOrDefault(c => c.id == id);

            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.customers.Remove(CustomerInDb);
            _context.SaveChanges();


        }
















    }
}
