using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly2.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer customer { get; set; }

        [Required]
        public Movie movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}