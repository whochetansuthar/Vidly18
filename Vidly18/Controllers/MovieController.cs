using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly18.Models;
using Vidly18.ViewModel;

namespace Vidly18.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            else
            {
                return View("IndexReadOnly");
            }
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x=>x.Genre).SingleOrDefault(x=>x.Id==id);
            if (movie == null)
            {
                return new HttpNotFoundResult();
            }
            return View(movie);
        }

        public ActionResult Movie(int? id)
        {
            Movie movie;

            if(id==null)
            {
                movie = new Movie();
            }
            else
            {
                movie = _context.Movies.SingleOrDefault(x=>x.Id==id);
            }
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movie
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var vm = new MovieViewModel
                {
                    Movie = new Movie(),
                    Genres = _context.Genres.ToList()
                };
                return RedirectToAction("Movie",vm);
            }
            if (movie.Id==0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                _context.Entry(movie).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}