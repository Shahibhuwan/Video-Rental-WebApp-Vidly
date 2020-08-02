using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext __context;

        public CustomersController()
        {
            __context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            __context.Dispose();
        }
        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return __context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        //when clients request for the customers data Customer Domainclass object is converted CustomerDtos object

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = __context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok (Mapper.Map<Customer,CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            __context.Customers.Add(customer);
            __context.SaveChanges();
            customerDto.Id= customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
            // Created, Ok, BadRequest are the http status code
            //when clients want to post/update for the customers data CustomerDtos class object is converted Customer Domain class object 
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = __context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            __context.SaveChanges();
                }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = __context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            __context.Customers.Remove(customerInDb);
            __context.SaveChanges();



        }



    }
}
