using _WebApp.Areas.Admin.Infrastructure;
using _WebApp.Areas.Admin.Models.Formulaires;
using _WebApp.Areas.Admin.Models.ViewModels;
using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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

        /***********************************************************************************************************
         *********************************************Departement***************************************************
         ***********************************************************************************************************/

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

        public ActionResult DetailsDep(int id) {
            DepartementService ds = new DepartementService();
            EmployeeService es = new EmployeeService();

            AdminDep ad = new AdminDep();
            ad.dep = ds.GetById(id);
            ad.ListEmpDep = es.GetByDep(id).OrderBy(r => r.Nom);
            ad.ListOtherEmp = es.GetOtherByDep(id).OrderBy(r => r.Nom);

            return View(ad);
        }

        public ActionResult AffecterEmployee(FormCollection listForm, int idDep) {
            listForm.Remove("idDep");
            List<int> listId = new List<int>();

            foreach (string item in listForm) {
                listId.Add(int.Parse(item));
            }

            DepartementService ds = new DepartementService();
            ds.AffecteEmployee(listId, idDep);

            return RedirectToAction("DetailsDep", "Admin", new { id = idDep });
        }

        //[HttpPost]
        //public ActionResult DetailsDep(int idEmp, int idDep) {
        //    DepartementService ds = new DepartementService();
        //    ds.AffecteEmployee(idEmp, idDep);

        //    return View();
        //}

        /***********************************************************************************************************
         ***********************************************Projet******************************************************
         ***********************************************************************************************************/

        public ActionResult Projet() {
            ProjetService ps = new ProjetService();

            return View(ps.GetAll());
        }

        public ActionResult CreateProjet() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProjet(CreateProjetForm form) {
            if (ModelState.IsValid) {
                ProjetService ps = new ProjetService();
                Projet p = new Projet(form.Nom, form.Description, form.DateDebut, form.DateFin, AdminSession.CurrentAdmin.NumeroAdmin);
                ps.Insert(p);

                return RedirectToAction("Index", "Admin");
            }
            return View(form);
        }
    }
}