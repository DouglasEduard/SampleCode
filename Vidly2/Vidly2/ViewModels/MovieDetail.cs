using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MovieDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "GenreId")]
        public int GenreId { get; set; }
        public string  Genre { get; set; }

        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }

        public string AddedDate { get; set; }

        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public IEnumerable<Genre> GenreList { get; set; }
    }
}