using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using AppCore.Entities;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostRepo _postRepo;

        public BlogController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        // GET: Blog
        public IActionResult Index()
        {
            return View(_postRepo.AllPosts());
        }

        // GET: Blog/Post/Permalink
        [Route("Post/{permalink?}")]
        public IActionResult Post(string permalink)
        {
            return View(_postRepo.GetByPermalink(permalink));
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post newPost, IFormCollection collection)
        {
            try
            {
                _postRepo.CreatePost(newPost);
                Console.Write("New Post Created.");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                Console.Write("Hey, You have an error exception in the Create method");
                throw ex;
            }
        }

        // GET: Blog/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blog/Edit/5
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

        // GET: Blog/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
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