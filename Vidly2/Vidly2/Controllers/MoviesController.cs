using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;
using System.Linq;


namespace Vidly2.Controllers
{    
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movie =
                _context.Movies.Include(c => c.Genre).ToList();

            return View(movie);
        }


        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            MovieDetail ResultView = new MovieDetail();
            ResultView.Name = movie.Name;
            ResultView.Genre = movie.Genre.Description;
            ResultView.ReleaseDate = movie.ReleaseDate == null ? "" : String.Format("{0:dddd, MMMM d, yyyy}", movie.ReleaseDate);
            ResultView.AddedDate = movie.ReleaseDate == null ? "" : String.Format("{0:dddd, MMMM d, yyyy}", movie.AddedDate);
            ResultView.NumberInStock = movie.NumberInStock;

            return View(ResultView);
        }         

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("Index = {0} & Sort = {1}", pageIndex, sortBy));
        //}

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}


    }
}