using BookLeague.Models.Group;
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
    public class GroupController : Controller
    {
        // GET: Group List
        public ActionResult Index()
        {
            var creatorId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroupService(creatorId);
            var model = service.GetGroup();

            return View(model);
        }

        // GET: Group Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGroupService();

            if (service.CreateGroup(model))
            {
                TempData["SaveResult"] = "Your group was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Group could not be created.");

            return View(model);
        }

        private GroupService CreateGroupService()
        {
            var creatorId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroupService(creatorId);
            return service;
        }
    }
}