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
            mi.ListP = ps.GetListByIdEmpl(IdEmp);

            EmployeeService es = new EmployeeService();
            mi.ListE = es.GetByEquipe(IdEmp);

            mi.ListEWDiscussion = es.GetWithDiscussion(IdEmp);

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
            MemberEquipe me = new MemberEquipe();

            EquipeService eqs = new EquipeService();
            Equipe eq = eqs.GetByEmployee((int)EmployeeSession.CurrentEmployee.Id);

            if (eq != null) {
                int? idEq = eq.Id;

                if (idEq != null && idEq != 0) {
                    me.eq = eqs.GetById((int)idEq);

                    EmployeeService es = new EmployeeService();
                    me.ListE = es.GetByEquipe((int)idEq);

                    MessageEquipeService mes = new MessageEquipeService();
                    me.ListMEq = mes.GetByEquipe((int)idEq);

                    DocumentService ds = new DocumentService();
                    me.ListD = ds.GetByEquipe((int)idEq);
                }
            }

            return View(me);
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
            MemberProjet mp = new MemberProjet();
            int IdEmp = (int)EmployeeSession.CurrentEmployee.Id;

            ProjetService ps = new ProjetService();

            if (id == 0) {
                Projet p = ps.GetByIdEmpl(IdEmp);

                if (p != null && p.Id != null) {
                    mp.p = ps.GetById((int)p.Id);
                    id = (int)mp.p.Id;
                }
            }

            if (id != 0) {
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
            }     

            return View(mp);
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
            MemberTacheEquipe mteq = new MemberTacheEquipe();

            TacheEquipeService teqs = new TacheEquipeService();
            mteq.te = teqs.GetById(id);

            MessageTacheService mteqq = new MessageTacheService();
            mteq.ListM = mteqq.GetByTacheId(id);

            DocumentService ds = new DocumentService();
            mteq.ListD = ds.GetByTache(id);

            return View(mteq);
        }
        public ActionResult TacheEmployee(int id) {
            MemberTacheEmployee mte = new MemberTacheEmployee();

            TacheEmployeeService teqs = new TacheEmployeeService();
            mte.te = teqs.GetById(id);

            MessageTacheService mtes = new MessageTacheService();
            mte.ListM = mtes.GetByTacheId(id);

            DocumentService ds = new DocumentService();
            mte.ListD = ds.GetByTache(id);

            return View(mte);

        }

        /***********************************************************************************************************
         ***********************************************Message*****************************************************
         ***********************************************************************************************************/

        [HttpPost]
        public ActionResult RepondreEmployee(int idDest, int? idMsg, string msg) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (!string.IsNullOrWhiteSpace(msg) && idDest != 0) {
                MessageEmployee me = new MessageEmployee { Titre = idMoi + "" + idDest, Contenu = msg, Date = DateTime.Now, Id_Employee = idMoi, Id_Destinataire = idDest, MessagePrecedent = idMsg };

                MessageEmployeeService mes = new MessageEmployeeService();
                mes.Insert(me);
            }

            return RedirectToAction("Employee", "Member", new { id = idDest});
        }

        [HttpPost]
        public ActionResult RepondreEquipe(int idEq, int? idMsg, string msg) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (!string.IsNullOrWhiteSpace(msg) && idEq != 0) {
                MessageEquipe me = new MessageEquipe { Titre = idMoi + "" + idEq, Contenu = msg, Date = DateTime.Now, Id_Employee = idMoi, Id_Equipe = idEq, MessagePrecedent = idMsg };

                MessageEquipeService mes = new MessageEquipeService();
                mes.Insert(me);
            }

            return RedirectToAction("Equipe", "Member", new { id = idEq });
        }

        [HttpPost]
        public ActionResult RepondreProjet(int idPr, int? idMsg, string msg) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (!string.IsNullOrWhiteSpace(msg) && idPr != 0) {
                MessageProjet mp = new MessageProjet { Titre = idMoi + "" + idPr, Contenu = msg, Date = DateTime.Now, Id_Employee = idMoi, Id_Projet = idPr, MessagePrecedent = idMsg };

                MessageProjetService mps = new MessageProjetService();
                mps.Insert(mp);
            }

            return RedirectToAction("Projet", "Member", new { id = idPr });
        }

        [HttpPost]
        public ActionResult RepondreTacheEmployee(int idTa, int? idMsg, string msg) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (!string.IsNullOrWhiteSpace(msg) && idTa != 0) {
                MessageTache mt = new MessageTache { Titre = idMoi + "" + idTa, Contenu = msg, Date = DateTime.Now, Id_Employee = idMoi, Id_Tache_Employee = idTa, Id_Tache_Equipe = null, MessagePrecedent = idMsg };

                MessageTacheService mps = new MessageTacheService();
                mps.Insert(mt);
            }

            return RedirectToAction("TacheEmployee", "Member", new { id = idTa });
        }

        [HttpPost]
        public ActionResult RepondreTacheEquipe(int idTa, int? idMsg, string msg) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (!string.IsNullOrWhiteSpace(msg) && idTa != 0) {
                MessageTache mt = new MessageTache { Titre = idMoi + "" + idTa, Contenu = msg, Date = DateTime.Now, Id_Employee = idMoi, Id_Tache_Employee = null, Id_Tache_Equipe = idTa, MessagePrecedent = idMsg };

                MessageTacheService mps = new MessageTacheService();
                mps.Insert(mt);
            }

            return RedirectToAction("TacheEquipe", "Member", new { id = idTa });
        }
    }
}