using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly1.Models;
using Vidly1.Dtos;
using Vidly1.App_Start;
using AutoMapper;

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

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersquery = _context.customers
                .Include(c => c.MembershipType);

                if(!string.IsNullOrWhiteSpace(query))
                    customersquery = customersquery.Where(c => c.name.Contains(query));

                var customerdtos = customersquery
                .ToList().Select(Mapper.Map<customer, CustomerDto>);
            return Ok(customerdtos);
 
        }
        // Get / Api / Customers / 1
      
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<customer, CustomerDto>(customer));
        }
         
        // Post / Api / Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, customer>(customerdto);
            _context.customers.Add(customer);
            _context.SaveChanges();
            customerdto.id = customer.id;
            return Created( new Uri(Request.RequestUri + "/" +customer.id), customerdto );

        }

        // Put / Api/ Customers /1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerdto )
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var CustomerInDb = _context.customers.SingleOrDefault(c => c.id == id);

            if (CustomerInDb == null)
                return NotFound();

            Mapper.Map(customerdto, CustomerInDb);

         

            _context.SaveChanges();

            return Ok();
        }

        // Delete / Api/ Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var CustomerInDb = _context.customers.SingleOrDefault(c => c.id == id);

            if (CustomerInDb == null)
                return NotFound();

            _context.customers.Remove(CustomerInDb);
            _context.SaveChanges();
            return Ok();


        }
















    }
}
