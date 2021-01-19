using BookLeague.Models;
using BookLeague.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLeague.WebMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        // GET: Book List
        public ActionResult Index()
        {
            var creatorId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(creatorId);
            var model = service.GetBooks();

            return View(model);
        }
        // GET Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBookService();

            if (service.CreateBook(model))
            {
                TempData["SaveResult"] = "Your book was created.";
                return RedirectToAction("index");
            };

            ModelState.AddModelError("", "Book could not be created.");

            return View(model);
        }

        private BookService CreateBookService()
        {
            var creatorId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(creatorId);
            return service;
        }
    }
}