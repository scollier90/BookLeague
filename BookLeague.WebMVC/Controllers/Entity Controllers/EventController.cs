using BookLeague.Models.Event;
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
    public class EventController : Controller
    {
        // GET: Event List
        public ActionResult Index()
        {
            var creatorId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(creatorId);
            var model = service.GetEvents();

            return View(model);
        }

        // GET: Event Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your event was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Event could not be created.");

            return View(model);
        }

        private EventService CreateEventService()
        {
            var creatorId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(creatorId);
            return service;
        }
    }
}