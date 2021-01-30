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

        public ActionResult Details(int id)
        {
            var svc = CreateGroupService();
            var model = svc.GetGroupById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGroupService();
            var detail = service.GetGroupById(id);
            var model =
                new GroupEdit
                {
                    GroupId = detail.GroupId,
                    GroupName = detail.GroupName
                    //Id = detail.Id -- future development
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GroupEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GroupId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGroupService();

            if (service.UpdateGroup(model))
            {
                TempData["SaveResult"] = "Your group was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your group could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGroupService();
            var model = svc.GetGroupById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGroup(int id)
        {
            var service = CreateGroupService();

            service.DeleteGroup(id);

            TempData["SaveResult"] = "Your group was deleted.";

            return RedirectToAction("Index");
        }
    }
}