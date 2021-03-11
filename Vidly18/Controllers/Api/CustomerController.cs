using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly18.Models;
using Vidly18.Dtos;
using AutoMapper;

namespace Vidly18.Controllers.Api
{
    public class CustomerController : ApiController
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            var list = _context.Customers.Include(x => x.MembershipType).ToList();
            return list;
        }

        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);
            if(customer==null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customer);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer==null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto,customer);
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Ok(customerDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
