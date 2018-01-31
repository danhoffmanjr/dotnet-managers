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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Blog/Score/5
        public IActionResult Score()
        {
            return View();
        }

        // POST: Blog/Score/
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Score/{id?}")]
        public IActionResult Score(int id, int awScore)
        {
            try
            {
                _postRepo.SetLastScore(id, awScore);
                return View(_postRepo.GetById(id));
            }
            catch (Exception ex)
            {
                Console.Write("Hey, You have an error exception in the Score method");
                throw ex;
            }
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveScore(int id, int awScore)
        {
            try
            {
                _postRepo.UpdateAwScore(id, awScore);
                string returnPerma = _postRepo.GetById(id).Permalink;
                return RedirectToAction(nameof(Post), new { permalink = returnPerma });
            }
            catch (Exception ex)
            {
                Console.Write("Hey, You have an error exception in the Save Score method");
                throw ex;
            }
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
            return View(_postRepo.GetById(id));
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post editedPost, IFormCollection collection)
        {
            try
            {
                _postRepo.UpdatePost(editedPost);

                string returnPerma = _postRepo.GetById(editedPost.Id).Permalink;
                return RedirectToAction(nameof(Post), new { permalink = returnPerma });
            }
            catch (Exception ex)
            {
                Console.Write("Hey, You have an error exception in the Update method");
                throw ex;
            }
        }

        // GET: Blog/Delete/5
        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(_postRepo.GetById(id));
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Post postToDelete)
        {
            try
            {
                _postRepo.DeletePost(postToDelete);

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