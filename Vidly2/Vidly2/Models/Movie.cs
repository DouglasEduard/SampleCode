using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.DTOs;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        public Nullable<DateTime> ReleaseDate { get; set; }
        public Nullable<DateTime> AddedDate { get; set; }
        public int NumberInStock { get; set; }
    }
}