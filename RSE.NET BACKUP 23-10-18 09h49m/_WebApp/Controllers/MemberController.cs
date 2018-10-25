using _WebApp.Infrastructure;
using _WebApp.Models.Formulaires;
using _WebApp.Models.ViewModels;
using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _WebApp.Controllers
{
    public class MemberController : Controller
    {
        [AuthRequiredAttribute]
        public ActionResult Index()
        {
            MemberIndex mi = new MemberIndex();
            ProjetService ps = new ProjetService();
            mi.ListP = ps.GetByIdEmpl((int)EmployeeSession.CurrentEmployee.Id);
            EmployeeService es = new EmployeeService();
            mi.ListE = es.GetByEquipe((int)EmployeeSession.CurrentEmployee.Id);

            return View(mi);
        }

        public ActionResult DetailsProjet(int id) {
            return View();
        }

        public ActionResult DetailsEmployee(int id) {
            return View();
        }
        
        public ActionResult CreateProjet() {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateProjet(ProjetForms form) {
            if (ModelState.IsValid) {
                Projet p = new Projet(form.Nom, form.Description, form.Debut, form.Fin, form.Admin);
                ProjetService ps = new ProjetService();
                ps.Insert(p);

                return RedirectToAction("Index", "Member");
            }
            return View(form);
        }
        
        public ActionResult EditProjet(int id) {
            return View();
        }
        
        [HttpPost]
        public ActionResult EditProjet(int id, ProjetForms collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}