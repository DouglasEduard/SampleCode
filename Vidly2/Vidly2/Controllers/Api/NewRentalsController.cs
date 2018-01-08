using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers.Single(
                           c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                         m => newRental.MovieIds.Contains(m.Id));

            foreach(var movie in movies)
            {
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    customer = customer,
                    movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }            
            
            _context.SaveChanges();

            return Ok();
        }
    }
}
