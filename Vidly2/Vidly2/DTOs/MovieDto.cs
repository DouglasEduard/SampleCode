using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Vidly2.Models;

namespace Vidly2.DTOs
{
    public class MovieDto
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