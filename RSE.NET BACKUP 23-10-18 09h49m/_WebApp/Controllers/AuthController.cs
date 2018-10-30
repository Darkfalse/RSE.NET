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
            return RedirectToAction("Index", "Home");
        }

        [AnonymousRequired]
        public ActionResult Register() {
            return View();
        }
        
        [AnonymousRequired]
        [HttpPost]
        public ActionResult Register(InscriptionForms form) {
            if (ModelState.IsValid) {
                //Récupere le pays depuis la base de données
                PaysService ps = new PaysService();
                Pays p = ps.GetByName(form.Pays);

                if (p != null) {
                    //Récupere la ville depuis la base de données
                    VilleService vs = new VilleService();
                    Ville v = vs.GetByNomZipPays(form.Ville, form.Zip, (int)p.Id);

                    if (v != null) {
                        AdresseService ads = new AdresseService();
                        Adresse a = new Adresse(form.Nom_Rue, form.Boite_Postal, (int)v.Id);
                        int idads = (int)ads.Insert(a).Id;

                        if (idads != 0) {
                            EmployeeService ur = new EmployeeService();
                            Employee e = new Employee(form.Nom, form.Prenom, form.Email, form.Password, form.Birthday, form.RegNat, idads, form.HireDate, form.Tel, null, false);
                            int idemp = (int)ur.Insert(e).Id;

                            if (idemp != 0) {
                                //TODO Sucess else msg erreur
                                ModelState.Clear();
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            return View(form);
        }

        [AnonymousRequired]
        public ActionResult Login() {
            return View();
        }

        [AnonymousRequired]
        [HttpPost]
        public ActionResult Login(LoginForm form) {
            if (ModelState.IsValid) {
                EmployeeService ur = new EmployeeService();
                Employee e = ur.GetByEmailPassword(form.Login, form.Password);
                if (e != null)
                {
                    EmployeeSession.CurrentEmployee = e;
                    return RedirectToAction("Index", "Member");
                }
                else {
                    ModelState.Clear();
                    return View();
                }
            }
            return View(form);
        }

        [AuthRequired]
        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}