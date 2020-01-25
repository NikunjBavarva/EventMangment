using EventManagment.Areas.Admin.Models;
using EventManagment.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagment.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        // GET: Index   
        public ActionResult Index()
        {
            CountryRepository CountryRepo = new CountryRepository();
            ModelState.Clear();
            return View(CountryRepo.GetAll());
        }
        // Create    
        public ActionResult Create()
        {
            return View();
        }
  
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CountryRepository CountryRepo = new CountryRepository();

                    if (CountryRepo.Add(country))
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
            CountryRepository countryRepo = new CountryRepository();
            return View(countryRepo.GetAll().Find(country => country.CountryId == id));
        }  
        [HttpPost]
        public ActionResult Edit(int id, Country obj)
        {
            try
            {
                CountryRepository countryRepo = new CountryRepository();

                countryRepo.Update(obj);
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
            CountryRepository countryRepo = new CountryRepository();
            return View(countryRepo.GetAll().Find(country => country.CountryId == id));
        }

        // Delete  
        public ActionResult Delete(int id)
        {
            try
            {
                CountryRepository countryRepo = new CountryRepository();
                if (countryRepo.Delete(id))
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