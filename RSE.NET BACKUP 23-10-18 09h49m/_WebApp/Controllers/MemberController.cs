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
    [AuthRequired]
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

        public ActionResult Equipe()
        {
            MemberEquipe me = new MemberEquipe();

            EquipeService eqs = new EquipeService();
            int? idEq = eqs.GetByEmployee((int)EmployeeSession.CurrentEmployee.Id).Id;

            if (idEq != null && idEq != 0) {
                me.eq = eqs.GetById((int)idEq);

                EmployeeService es = new EmployeeService();
                me.ListE = es.GetByEquipe((int)idEq);

                MessageEquipeService mes = new MessageEquipeService();
                me.ListMEq = mes.GetByEquipe((int)idEq);

                DocumentService ds = new DocumentService();
                me.ListD = ds.GetByEquipe((int)idEq);
            }

            return View(me);
        }

        /***********************************************************************************************************
         ***********************************************Employee****************************************************
         ***********************************************************************************************************/
        //public ActionResult Employee(int id)
        //{
        //    return View();
        //}

        /***********************************************************************************************************
         ************************************************Projet*****************************************************
         ***********************************************************************************************************/
        //public ActionResult Projet() {
        //    int IdEmp = (int)EmployeeSession.CurrentEmployee.Id;

        //    ProjetService ps = new ProjetService();

        //    return View(ps.GetByIdEmpl(IdEmp).First().Id);
        //}

        public ActionResult Projet(int id = 0)
        {
            MemberProjet mp = new MemberProjet();
            int IdEmp = (int)EmployeeSession.CurrentEmployee.Id;

            ProjetService ps = new ProjetService();
            if (id == 0)
                id = (int)ps.GetByIdEmpl(IdEmp).First().Id;
            mp.p = ps.GetById(id);

            EmployeeService ems = new EmployeeService();
            mp.chef = ems.GetManagerByProjet(id);

            TacheEmployeeService tes = new TacheEmployeeService();
            mp.TacheEmployees = tes.GetByEmployee(IdEmp);

            TacheEquipeService teq = new TacheEquipeService();
            mp.TacheEquipes = teq.GetByProjet(id);

            MessageProjetService mps = new MessageProjetService();
            mp.MessageProjets = mps.GetByProjet(id);

            DocumentService ds = new DocumentService();
            mp.Documents = ds.GetByProjet(id);

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

            return View(mt);
        }
    }
}