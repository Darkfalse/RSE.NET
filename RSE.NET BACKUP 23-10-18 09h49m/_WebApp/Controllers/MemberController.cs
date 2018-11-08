using _WebApp.Infrastructure;
using _WebApp.Models.Formulaires;
using _WebApp.Models.ViewModels;
using Client.Models;
using Client.Services;
using System;
using System.Collections;
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
            int idEmp = (int) EmployeeSession.CurrentEmployee.Id;

            ProjetService ps = new ProjetService();
            mi.ListP = ps.GetListByIdEmpl(idEmp);

            EmployeeService es = new EmployeeService();
            mi.ListE = es.GetByEquipe(idEmp);

            mi.ListEWDiscussion = es.GetWithDiscussion(idEmp);

            MessageEmployeeService mes = new MessageEmployeeService();
            mi.ListME = mes.GetAll();

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
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;
                           
            MemberEquipe me = new MemberEquipe();

            EquipeService eqs = new EquipeService();
            Equipe eq = eqs.GetByEmployee(idMoi);

            if (eq != null) {
                int? idEq = eq.Id;

                if (idEq != null && idEq != 0) {
                    /*EmployeeService ems = new EmployeeService();
                    //Verifie si l'utilisateur courrant a accès à l'équipe 'idEq'
                    Employee e = ems.GetByEquipe((int)idEq).Where(r => r.Id == idMoi).SingleOrDefault();

                    if (e != null) {*/
                        me.eq = eqs.GetById((int)idEq);

                        EmployeeService es = new EmployeeService();
                        me.ListE = es.GetByEquipe((int)idEq);

                        MessageEquipeService mes = new MessageEquipeService();
                        me.ListMEq = mes.GetSujetByEquipe((int)idEq);

                        DocumentService ds = new DocumentService();
                        me.ListD = ds.GetByEquipe((int)idEq);

                        return View(me);
                    //}
                }
            }
            return RedirectToAction("Index", "Error");
        }

        /***********************************************************************************************************
         ***********************************************Employee****************************************************
         ***********************************************************************************************************/
        public ActionResult Employee(int id) {
            MemberDiscussion md = new MemberDiscussion();

            EmployeeService es = new EmployeeService();
            md.employee = es.GetById(id);

            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;
            MessageEmployeeService mes = new MessageEmployeeService();

            md.ListeMessageEmployees = mes.GetDiscution(idMoi, id);

            return View(md);
        }

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
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;
            
            MemberProjet mp = new MemberProjet();
            ProjetService ps = new ProjetService();

            if (id == 0) {
                //Récupere le premier projet de l'utilisateur
                Projet p = ps.GetByIdEmpl(idMoi).FirstOrDefault();

                if (p != null && p.Id != null) {
                    mp.p = p;
                    id = (int)p.Id;
                }
                else {
                    //Aucun projet assigner
                    return RedirectToAction("Index", "Member");
                }
            }
            else {
                mp.p = ps.GetById(id);
            }

            if (id != 0) {
                EmployeeService ems = new EmployeeService();
                //Verifie si l'utilisateur courrant a accès au projet 'id'
                Employee e = ems.GetByProjet(id).Where(r => r.Id == idMoi).SingleOrDefault();

                if (e != null) {
                    mp.chef = ems.GetManagerByProjet(id);

                    TacheEmployeeService tes = new TacheEmployeeService();
                    mp.TacheEmployees = tes.GetByEmployee(idMoi);

                    TacheEquipeService teq = new TacheEquipeService();
                    mp.TacheEquipes = teq.GetByProjet(id);

                    MessageProjetService mps = new MessageProjetService();
                    mp.MessageProjets = mps.GetSujetByProjet(id);

                    DocumentService ds = new DocumentService();
                    mp.Documents = ds.GetByProjet(id);

                    return View(mp);
                }
            }
            return RedirectToAction("Index", "Error");
        }

        //public ActionResult CreateProjet()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateProjet(ProjetForms form)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Projet p = new Projet(form.Nom, form.Description, form.Debut, form.Fin, form.Admin);
        //        ProjetService ps = new ProjetService();
        //        ps.Insert(p);

        //        return RedirectToAction("Index", "Member");
        //    }
        //    return View(form);
        //}

        /***********************************************************************************************************
         ***********************************************Taches******************************************************
         ***********************************************************************************************************/

        public ActionResult TacheEquipe(int id) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;
            
            EmployeeService ems = new EmployeeService();
            //Verifie si l'utilisateur courrant a accès a la tache equipe 'id'
            Employee e = ems.GetByTacheEquipe(id).Where(r => r.Id == idMoi).SingleOrDefault();

            if (e != null) {
                MemberTacheEquipe mteq = new MemberTacheEquipe();

                TacheEquipeService teqs = new TacheEquipeService();
                mteq.te = teqs.GetById(id);

                MessageTacheService mteqq = new MessageTacheService();
                mteq.ListM = mteqq.GetSujetByTacheId(id);

                DocumentService ds = new DocumentService();
                mteq.ListD = ds.GetByTache(id);

                return View(mteq);
            }
            return RedirectToAction("Index", "Error");
        }
        public ActionResult TacheEmployee(int id) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;
            
            EmployeeService ems = new EmployeeService();
            //Verifie si l'utilisateur courrant a accès a la tache employee 'id'
            Employee e = ems.GetByTacheEmployee(id).Where(r => r.Id == idMoi).SingleOrDefault();

            if (e != null) {
                MemberTacheEmployee mte = new MemberTacheEmployee();

                TacheEmployeeService teqs = new TacheEmployeeService();
                mte.te = teqs.GetById(id);

                MessageTacheService mtes = new MessageTacheService();
                mte.ListM = mtes.GetSujetByTacheId(id);

                DocumentService ds = new DocumentService();
                mte.ListD = ds.GetByTache(id);

                return View(mte);
            }
            return RedirectToAction("Index", "Error");
        }
    }
}