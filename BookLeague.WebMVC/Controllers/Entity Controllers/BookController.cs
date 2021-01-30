using BookLeague.Models;
using BookLeague.Models.Book;
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

        public ActionResult Details(int id)
        {
            var svc = CreateBookService();
            var model = svc.GetBookById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBookService();
            var detail = service.GetBookById(id);
            var model =
                new BookEdit
                {
                    BookId = detail.BookId,
                    BookName = detail.BookName,
                    Genre = detail.Genre,
                    Rating = detail.Rating,
                    Price = detail.Price,
                    PageCount = detail.PageCount,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.BookId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBookService();

            if (service.UpdateBook(model))
            {
                TempData["SaveResult"] = "Your book was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your book could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBookService();
            var model = svc.GetBookById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook(int id)
        {
            var service = CreateBookService();

            service.DeleteBook(id);

            TempData["SaveResult"] = "Your book was deleted.";

            return RedirectToAction("Index");
        }
    }
}