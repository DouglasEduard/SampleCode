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

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "GenreId")]        
        public int GenreId { get; set; }
        public string  Genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }

        public string AddedDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public IEnumerable<Genre> GenreList { get; set; }

        public string Title
        {
            get
            {
               return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }

        public MovieDetail()
        {
            Id = 0;
        }

        public MovieDetail(Movie movie)
        {
            Name = movie.Name;
            Genre = movie.Genre.Description;
            ReleaseDate = movie.ReleaseDate == null ? "" : String.Format("{0:dddd, MMMM d, yyyy}", movie.ReleaseDate);
            AddedDate = movie.ReleaseDate == null ? "" : String.Format("{0:dddd, MMMM d, yyyy}", movie.AddedDate);
            NumberInStock = movie.NumberInStock;
        }
    }
}