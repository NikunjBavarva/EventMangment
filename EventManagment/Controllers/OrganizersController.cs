using EventManagment.Areas.Admin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagment.Controllers
{
    public class OrganizersController : Controller
    {
        // GET: Organizer
        public ActionResult Index()
        {
            OrganizerRepository OrgRepo = new OrganizerRepository();
            ModelState.Clear();
            return View(OrgRepo.GetAll());
        }
    }
}