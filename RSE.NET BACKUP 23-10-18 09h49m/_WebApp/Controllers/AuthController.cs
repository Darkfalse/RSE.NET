using _WebApp.Infrastructure;
using _WebApp.Models.Formulaires;
using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _WebApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [AnonymousRequired]
        public ActionResult Register() {
            return View();
        }

        //TODO
        //[AnonymousRequired]
        //[HttpPost]
        //public ActionResult Register(InscriptionForms form) {
        //    if (ModelState.IsValid) {
        //        EmployeeService ur = new EmployeeService();
        //        Employee e = new Employee(form.Nom, form.Prenom, form.Email, form.Password, form.Birthday, form.RegNat, form.Adresse, form.HireDate, form.Tel, form.Coordonnee, form.Valide);
        //        //Adresse a = 
        //        e.Id = ur.Insert(e);
        //        TempData["msg"] = "Inscription réussie";
        //        ModelState.Clear();
        //        return View();
        //    }
        //    return View(form);
        //}

        [AnonymousRequired]
        public ActionResult Login() {
            return View();
        }

        //[AnonymousRequired]
        //[HttpPost]
        //public ActionResult Login(LoginForm form) {
        //    if (ModelState.IsValid) {
        //        EmployeeService ur = new EmployeeService();
        //        Employee e = ur.GetUserByEmailPassword(form.Login, form.Password);
        //        if (e != null)// && SecuredPassword.Verify(form.Password, u.Password))
        //        {
        //            TempData["nomUser"] = e.FirstName;
        //            EmployeeSession.CurrentEmployee = new Employee() { Id = e.Id, Email = form.Login };
        //            return RedirectToAction("Index", "Member");
        //        }
        //        else {
        //            TempData["loginError"] = "Login ou mot de passe incorrect.";
        //            ModelState.Clear();
        //            return View();
        //        }
        //    }
        //    return View(form);
        //}

        [AuthRequired]
        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}