using EventManagment.Areas.Admin.Models;
using EventManagment.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagment.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        // GET: Index   
        public ActionResult Index()
        {
            CityRepository CityRepo = new CityRepository();
            ModelState.Clear();
            return View(CityRepo.GetAll());
        }
        // Create    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CityRepository StateRepo = new CityRepository();

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
            CityRepository CityRepo = new CityRepository();
            return View(CityRepo.GetAll().Find(City => City.CityId == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, City obj)
        {
            try
            {
                CityRepository CityRepo = new CityRepository();

                CityRepo.Update(obj);
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
            CityRepository CityRepo = new CityRepository();
            return View(CityRepo.GetAll().Find(City => City.CityId == id));
        }

        // Delete  
        public ActionResult Delete(int id)
        {
            try
            {
                CityRepository CityRepo = new CityRepository();
                if (CityRepo.Delete(id))
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