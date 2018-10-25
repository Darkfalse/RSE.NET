using _WebApp.Infrastructure;
using _WebApp.Models.ViewModels;
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
            mi.ListP = ps.GetAll();
            EmployeeService es = new EmployeeService();
            mi.ListE = es.GetAll();

            return View(mi);
        }

        public ActionResult DetailsProjet(int id) {
            return View();
        }

        public ActionResult DetailsEmployee(int id) {
            return View();
        }
        
        public ActionResult CreateProjet() {
            //TODO
            return View();
        }

        // POST: Member2/Create
        [HttpPost]
        public ActionResult CreateProjet(ProjetForm form) {
            
            return View();
        }

        // GET: Member2/Edit/5
        public ActionResult EditProjet(int id) {
            return View();
        }

        // POST: Member2/Edit/5
        [HttpPost]
        public ActionResult EditProjet(int id, ProjetForm collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Member2/Delete/5
        public ActionResult DeleteProjet(int id) {
            return View();
        }

        // POST: Member2/Delete/5
        [HttpPost]
        public ActionResult DeleteProjet(int id, ProjetForm collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}