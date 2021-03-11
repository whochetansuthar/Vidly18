using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly18.Dtos;
using Vidly18.Models;

namespace Vidly18.Controllers.Api
{
    public class RentedController : ApiController
    {
        ApplicationDbContext _context;
        public RentedController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Save(NewRentalDto newRentalDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            foreach (var item in newRentalDto.MovieIds)
            {
                var movie = _context.Movies.SingleOrDefault(x=>x.Id==item);
                if (movie.AvailableStock<=0)
                {
                    return BadRequest();
                }
                movie.AvailableStock--;
                var rented = new Rented {
                    CustomerId = newRentalDto.CustomerId,
                    MovieId = item,
                    DateRented = DateTime.Today,
                };
                _context.Renteds.Add(rented);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}