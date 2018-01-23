using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary;
using MovieManager.Models;

namespace MovieManager.Controllers
{
    public class HomeController : Controller
    {
        private MovieRepo _movieRepo = new MovieRepo();

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        // GET: Movies
        public IActionResult Index()
        {
            if (_movieRepo.MoviesLength() == 0)
            {
                Movie brainCandy = new Movie
                {
                    Id = 0,
                    Title = "Brain Candy",
                    Director = "Kelly Makin",
                    Genre = "Comedy",
                    ShortDesc = "A pharmaceutical scientist creates a pill that makes people remember their happiest memory, and although it's successful, it has unfortunate side effects.",
                    ReleaseDate = DateTime.Parse("04/16/1996"),
                    Rated = "R",
                    RunTime = TimeSpan.Parse("1:29"),
                    Rating = 6.9M
                };

                _movieRepo.AddMovie(brainCandy);
            }

            return View(_movieRepo.GetMovies());
        }

        // GET: Movie/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie newMovieFromPost)
        {
            try
            {

                _movieRepo.AddMovie(newMovieFromPost);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
