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
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            try {
               
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
                        me.ListMEq = mes.GetSujetByEquipe((int)idEq);

                        DocumentService ds = new DocumentService();
                        me.ListD = ds.GetByEquipe((int)idEq);
                    }
                }
                return View(me);
            }
            catch (Exception e) when (e is ArgumentNullException || e is InvalidOperationException) {
                return RedirectToAction("Index", "Error");
            }
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

            try {
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
                    Employee e = ems.GetByProjet(id).Where(r => r.Id == idMoi).Single();

                    mp.chef = ems.GetManagerByProjet(id);

                    TacheEmployeeService tes = new TacheEmployeeService();
                    mp.TacheEmployees = tes.GetByEmployee(idMoi);

                    TacheEquipeService teq = new TacheEquipeService();
                    mp.TacheEquipes = teq.GetByProjet(id);

                    MessageProjetService mps = new MessageProjetService();
                    mp.MessageProjets = mps.GetSujetByProjet(id);

                    DocumentService ds = new DocumentService();
                    mp.Documents = ds.GetByProjet(id);
                }

                return View(mp);
            }
            catch (Exception e) when (e is ArgumentNullException || e is InvalidOperationException) {
                return RedirectToAction("Index", "Error");
            }
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
            
            try {
                EmployeeService ems = new EmployeeService();
                //Verifie si l'utilisateur courrant a accès a la tache equipe 'id'
                Employee e = ems.GetByTacheEquipe(id).Where(r => r.Id == idMoi).Single();

                MemberTacheEquipe mteq = new MemberTacheEquipe();

                TacheEquipeService teqs = new TacheEquipeService();
                mteq.te = teqs.GetById(id);

                MessageTacheService mteqq = new MessageTacheService();
                mteq.ListM = mteqq.GetSujetByTacheId(id);

                DocumentService ds = new DocumentService();
                mteq.ListD = ds.GetByTache(id);

                return View(mteq);
            }
            catch (Exception e) when (e is ArgumentNullException || e is InvalidOperationException){
                return RedirectToAction("Index", "Error");
            }
            
        }
        public ActionResult TacheEmployee(int id) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            try {
                EmployeeService ems = new EmployeeService();
                //Verifie si l'utilisateur courrant a accès a la tache employee 'id'
                Employee e = ems.GetByTacheEmployee(id).Where(r => r.Id == idMoi).Single();

                MemberTacheEmployee mte = new MemberTacheEmployee();

                TacheEmployeeService teqs = new TacheEmployeeService();
                mte.te = teqs.GetById(id);

                MessageTacheService mtes = new MessageTacheService();
                mte.ListM = mtes.GetSujetByTacheId(id);

                DocumentService ds = new DocumentService();
                mte.ListD = ds.GetByTache(id);

                return View(mte);
            }
            catch (Exception e) when(e is ArgumentNullException || e is InvalidOperationException) {
                return RedirectToAction("Index", "Error");
            }
        }

        /***********************************************************************************************************
         ***********************************************Message*****************************************************
         ***********************************************************************************************************/

        public ActionResult MessageEquipe(int id) {
            MessageEquipeService mes = new MessageEquipeService();

            return View(mes.GetMessageBySujet(id));
        }

        public ActionResult MessageProjet(int id) {
            MessageProjetService mps = new MessageProjetService();

            return View(mps.GetMessageBySujet(id));
        }

        public ActionResult MessageTacheEquipe(int id) {
            MessageTacheService mts = new MessageTacheService();

            return View(mts.GetMessageBySujet(id));
        }

        /***********************************************************************************************************
         *******************************************RéponseMessage**************************************************
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