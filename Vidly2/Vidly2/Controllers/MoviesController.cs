using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Validation;

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
            var movieList =
                _context.Movies.Include(c => c.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List", movieList);

            return View("ReadyOnlyList", movieList);
        }


        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            MovieDetail ResultView = new MovieDetail(movie);

            return View(ResultView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieDetail(movie)
                {
                    GenreList = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            try
            {
                if (movie.Id == 0)
                {
                    movie.AddedDate = DateTime.UtcNow;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                    MovieInDb.Name = movie.Name;
                    MovieInDb.GenreId = movie.GenreId;
                    MovieInDb.ReleaseDate = movie.ReleaseDate;
                    MovieInDb.NumberInStock = movie.NumberInStock;
                }

                _context.SaveChanges();

            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            MovieDetail ResultView = new MovieDetail();

            ResultView.Id = 0;
            ResultView.GenreList = _context.Genres.ToList();

            return View("MovieForm", ResultView);
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