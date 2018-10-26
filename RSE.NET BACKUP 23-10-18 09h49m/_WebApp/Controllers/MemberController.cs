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
    [AuthRequiredAttribute]
    public class MemberController : Controller
    {
        public ActionResult Index()
        {
            MemberIndex mi = new MemberIndex();
            int IdEmp = (int)EmployeeSession.CurrentEmployee.Id;
            ProjetService ps = new ProjetService();
            mi.ListP = ps.GetByIdEmpl(IdEmp);
            EmployeeService es = new EmployeeService();
            mi.ListE = es.GetByEquipe(IdEmp);
            MessageEmployeeService mes = new MessageEmployeeService();
            mi.ListME = mes.GetByDestinataire(IdEmp);

            return View(mi);
        }

        /***********************************************************************************************************
         ***********************************************Equipe******************************************************
         ***********************************************************************************************************/
        public ActionResult Equipe() {
            EmployeeService es = new EmployeeService();
            return View(es.GetByEquipe((int)EmployeeSession.CurrentEmployee.Id).First().Id);
        }

        public ActionResult Equipe(int id) {
            return View();
        }

        /***********************************************************************************************************
         ***********************************************Employee****************************************************
         ***********************************************************************************************************/
        public ActionResult Employee(int id) {
            return View();
        }

        /***********************************************************************************************************
         ***********************************************Projet******************************************************
         ***********************************************************************************************************/
        public ActionResult Projet() {
            ProjetService ps = new ProjetService();
            return View(ps.GetByIdEmpl((int)EmployeeSession.CurrentEmployee.Id).First().Id);
        }

        public ActionResult Projet(int id) {
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