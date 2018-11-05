using _WebApp.Areas.Admin.Infrastructure;
using _WebApp.Areas.Admin.Models.Formulaires;
using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _WebApp.Areas.Admin.Controllers
{
    [AdminRequired]
    public class AdminController : Controller
    {
        
        public ActionResult Index()
        {
            DepartementService ds = new DepartementService();

            //TODO Afficher les departements
            return View(ds.GetAll());
        }

        public ActionResult CreateDep() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDep(CreateDepForm form) {
            if (ModelState.IsValid) {
                DepartementService ds = new DepartementService();
                Departement d = new Departement(form.Nom, form.Description, AdminSession.CurrentAdmin.NumeroAdmin);
                d = ds.Insert(d);

                return RedirectToAction("Index", "Admin");
            }
            return View(form);
        }

        public ActionResult DeleteDep(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteDep(int id) {
            DepartementService ds = new DepartementService();
            if (ds.Delete(id))
                return RedirectToAction("Index", "Admin");
            return RedirectToAction("DeleteDep", "Admin", id);
        }
    }
}