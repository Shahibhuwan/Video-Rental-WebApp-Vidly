using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


using System.Data.Entity;


namespace Vidly.Controllers
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
        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovie))
                return View();

            return View("ReadOnlyList");
            
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        [Authorize(Roles = RoleName.CanManageMovie)]

        public ActionResult New()
        {
            var movie = new Movie { ReleaseDate = DateTime.Now };
            
            var viewModel = new NewMovieViewModel
            {
                Movie= new Movie(),
                Genres = _context.Genres.ToList()                                              //here we have  collected data of membershiptype table into membershiptypes variable then we have palced memebershiptype varibledata into the object of newcoustomerviewmodel class of viewmodel ie enumurable of membershiptype  
        };
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovie)]

        public ActionResult Create(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else    // data are inserted into properties of the model class and from database data and its properties are reterive than overwritten or compared
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.StockNumber = movie.StockNumber;
                movieInDb.AddedDate = movie.AddedDate;

            }
            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = RoleName.CanManageMovie)]

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
            Genres = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}
