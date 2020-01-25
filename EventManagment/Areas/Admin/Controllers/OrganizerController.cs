using EventManagment.Areas.Admin.Models;
using EventManagment.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagment.Areas.Admin.Controllers
{
    public class OrganizerController : Controller
    {
        // GET: Index   
        public ActionResult Index()
        {
            OrganizerRepository OrgRepo = new OrganizerRepository();
            ModelState.Clear();
            return View(OrgRepo.GetAll());
        }
        // Create    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Organizer obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrganizerRepository OrgRepo = new OrganizerRepository();

                    if (OrgRepo.Add(obj))
                    {
                        ViewBag.Message = "Details added successfully";
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Edit    
        public ActionResult Edit(int id)
        {
            OrganizerRepository OrgRepo = new OrganizerRepository();
            return View(OrgRepo.GetAll().Find(Organizer => Organizer.EventId == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Organizer obj)
        {
            try
            {
                OrganizerRepository OrgRepo = new OrganizerRepository();

                OrgRepo.Update(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Details
        public ActionResult Details(int id)
        {
            OrganizerRepository OrgRepo = new OrganizerRepository();
            return View(OrgRepo.GetAll().Find(Organizer => Organizer.EventId == id));
        }

        // Delete  
        public ActionResult Delete(int id)
        {
            try
            {
                OrganizerRepository OrgRepo = new OrganizerRepository();
                if (OrgRepo.Delete(id))
                {
                    ViewBag.AlertMsg = "Details deleted successfully";

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}