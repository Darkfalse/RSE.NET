using _WebApp.Infrastructure;
using Client.Models;
using Client.Services;
using _WebApp.Areas.Admin.Models.Formulaires;
using _WebApp.Areas.Admin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _WebApp.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Auth");
        }
        
        public ActionResult Login() {

            if (EmployeeSession.CurrentEmployee != null && EmployeeSession.CurrentEmployee.Id != null) {
                AdministrateurService ads = new AdministrateurService();
                Administrateur a = ads.GetByIdEmployee((int)EmployeeSession.CurrentEmployee.Id);

                if (a != null) {
                    AdminSession.CurrentEmployee = EmployeeSession.CurrentEmployee;
                    AdminSession.CurrentAdmin = a;
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
            }

            return View();
        }

        [AnonymousRequired]
        [HttpPost]
        public ActionResult Login(LoginForm form) {
            if (ModelState.IsValid) {
                EmployeeService us = new EmployeeService();
                Employee e = us.GetByEmailPassword(form.Login, form.Password);
                
                if (e != null) {
                    AdministrateurService ads = new AdministrateurService();
                    Administrateur a = ads.GetByIdEmployee((int)e.Id);

                    if (a != null) {
                        AdminSession.CurrentEmployee = e;
                        AdminSession.CurrentAdmin = a;
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else {
                    ModelState.Clear();
                    return View();
                }
            }
            return View(form);
        }

        [AdminRequired]
        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Login", "Auth");
        }
    }
}