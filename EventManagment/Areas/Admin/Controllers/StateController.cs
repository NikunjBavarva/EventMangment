using EventManagment.Areas.Admin.Models;
using EventManagment.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagment.Areas.Admin.Controllers
{
    public class StateController : Controller
    {
        // GET: Index   
        public ActionResult Index()
        {
            StateRepository StateRepo = new StateRepository();
            ModelState.Clear();
            return View(StateRepo.GetAll());
        }
        // Create    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(State obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StateRepository StateRepo = new StateRepository();

                    if (StateRepo.Add(obj))
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
            StateRepository StateRepo = new StateRepository();
            return View(StateRepo.GetAll().Find(State => State.StateId == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, State obj)
        {
            try
            {
                StateRepository StateRepo = new StateRepository();

                StateRepo.Update(obj);
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
            StateRepository StateRepo = new StateRepository();
            return View(StateRepo.GetAll().Find(State => State.StateId == id));
        }

        // Delete  
        public ActionResult Delete(int id)
        {
            try
            {
                StateRepository StateRepo = new StateRepository();
                if (StateRepo.Delete(id))
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