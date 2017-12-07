using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.ViewModels
{
    public class MovieDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string ReleaseDate { get; set; }
        public string AddedDate { get; set; }
        public int NumberInStock { get; set; }
    }
}