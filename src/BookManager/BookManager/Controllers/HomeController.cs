using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookManager.Models;
using BookLibrary;

namespace BookManager.Controllers
{
    public class HomeController : Controller
    {
        private BookRepo _bookRepo = new BookRepo();

        // GET: BookManager
        public ActionResult Index()
        {
            if (_bookRepo.GetNumBooks() == 0)
            {
                var siddhartha = new Book
                {
                    Year = 1951,
                    Title = "Siddhartha",
                    Author = "Hermann Hesse",
                    Publisher = "New Directions",
                    NumOfPages = 152,
                    ISBN = 0553208845
                };

                var mobyDick = new Book
                {
                    Year = 1851,
                    Title = "Moby Dick",
                    Author = "Herman Melville",
                    Publisher = "Harper & Brothers",
                    NumOfPages = 720,
                    ISBN = 0142437247
                };

                _bookRepo.AddBook(siddhartha);
                _bookRepo.AddBook(mobyDick);
            }

            return View(_bookRepo.ListAll());
        }

        // GET: BookManager/Details/5
        public ActionResult Details(int id)
        {
            return View(_bookRepo.GetById(id));
        }

        // GET: BookManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book newBook, IFormCollection collection)
        {
            try
            {
                _bookRepo.AddBook(newBook);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bookRepo.GetById(id));
        }

        // POST: BookManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book editBook, int id, IFormCollection collection)
        {
            try
            {
                _bookRepo.EditBook(editBook);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_bookRepo.GetById(id));
        }

        // POST: BookManager/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _bookRepo.DeleteBook(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
