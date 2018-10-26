﻿using _WebApp.Infrastructure;
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
            int IdEmp = (int) EmployeeSession.CurrentEmployee.Id;

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
        //public ActionResult Equipe()
        //{
        //    EmployeeService es = new EmployeeService();
        //    return View(es.GetByEquipe((int) EmployeeSession.CurrentEmployee.Id).First().Id);
        //}

        public ActionResult Equipe(int id)
        {
            MemberEquipe me = new MemberEquipe();

            EquipeService eqs = new EquipeService();
            me.eq = eqs.GetById(id);

            EmployeeService es = new EmployeeService();
            me.ListE = es.GetByEquipe(id);

            MessageEquipeService mes = new MessageEquipeService();
            me.ListMEq = mes.GetByEquipe(id);

            DocumentService ds = new DocumentService();
            me.ListD = ds.GetAll(); //TODO XAV trier les docs GetByEquipe(id)

            return View(me);
        }

        /***********************************************************************************************************
         ***********************************************Employee****************************************************
         ***********************************************************************************************************/
        public ActionResult Employee(int id)
        {
            return View();
        }

        /***********************************************************************************************************
         ***********************************************Projet******************************************************
         ***********************************************************************************************************/
        //public ActionResult Projet()
        //{
        //    ProjetService ps = new ProjetService();
        //    return View(ps.GetByIdEmpl((int) EmployeeSession.CurrentEmployee.Id).First().Id);
        //}

        public ActionResult Projet(int id)
        {
            MemberProjet mp = new MemberProjet();
            int IdEmp = (int)EmployeeSession.CurrentEmployee.Id;

            ProjetService ps = new ProjetService();
            mp.p = ps.GetById(id);

            TacheEmployeeService tes = new TacheEmployeeService();
            mp.TacheEmployees = tes.GetByEmployee(IdEmp); //TODO XAV utile d'afficher les msg employee dans projet ?

            TacheEquipeService teq = new TacheEquipeService();
            mp.TacheEquipes = teq.GetByProjet(id);

            MessageProjetService mps = new MessageProjetService();
            mp.MessageProjets = mps.GetByProjet(id);

            DocumentService ds = new DocumentService();
            mp.Documents = ds.GetAll(); //TODO XAV trier les docs GetByProjet(id)

            return View(mp);
        }

        public ActionResult CreateProjet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProjet(ProjetForms form)
        {
            if (ModelState.IsValid)
            {
                Projet p = new Projet(form.Nom, form.Description, form.Debut, form.Fin, form.Admin);
                ProjetService ps = new ProjetService();
                ps.Insert(p);

                return RedirectToAction("Index", "Member");
            }

            return View(form);
        }

        /***********************************************************************************************************
         ***********************************************Taches******************************************************
         ***********************************************************************************************************/

        public ActionResult Tache(int id) {
            MemberTache mt = new MemberTache();

            TacheEquipeService teqs = new TacheEquipeService(); //TODO XAV différentier tache equipe et employee
            mt.te = teqs.GetById(id);

            MessageTacheService mteq = new MessageTacheService();
            mt.ListM = mteq.GetAll(); //TODO XAV GetByTache(id)

            return View();
        }
    }
}