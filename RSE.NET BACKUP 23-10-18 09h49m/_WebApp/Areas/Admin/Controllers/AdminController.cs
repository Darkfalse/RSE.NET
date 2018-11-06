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

        public ActionResult EditDep(int id) {
            DepartementService ds = new DepartementService();
            Departement d = ds.GetById(id);

            EditDepForm form = new EditDepForm();
            form.Id = (int)d.Id;
            form.Nom = d.Nom;
            form.Description = d.Description;

            return View(form);
        }

        [HttpPost]
        public ActionResult EditDep(EditDepForm form) {
            if (ModelState.IsValid) {
                DepartementService ds = new DepartementService();
                Departement d = new Departement(form.Id, form.Nom, form.Description, AdminSession.CurrentAdmin.NumeroAdmin);
                if (ds.Update(d))
                    return RedirectToAction("Index", "Admin");
            }
            return View(form);
        }

        public ActionResult DeleteDep(int id)
        {
            if (id != 0)
            {
                DepartementService ds = new DepartementService();
                return View(ds.GetById(id));
            }
            return View();
        }

        
        public ActionResult DeleteDep2(int id) {
            DepartementService ds = new DepartementService();
            if (ds.Delete(id))
                return RedirectToAction("Index", "Admin");
            return RedirectToAction("DeleteDep", "Admin", id);
        }
    }
}