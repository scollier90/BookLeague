using BookLeague.Models;
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
        // GET List
        public ActionResult Index()
        {
            var model = new BookListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}