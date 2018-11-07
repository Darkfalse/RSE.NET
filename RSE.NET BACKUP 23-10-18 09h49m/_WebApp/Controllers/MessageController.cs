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
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
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

            return RedirectToAction("Employee", "Member", new { id = idDest });
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

        /***********************************************************************************************************
         *********************************************NouveauSujet**************************************************
         ***********************************************************************************************************/

        public ActionResult CreateSujetEquipe(int id) {
            TempData["idEq"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSujetEquipe(SujetForm form) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (ModelState.IsValid) {
                MessageEquipeService mes = new MessageEquipeService();
                MessageEquipe me = new MessageEquipe(form.Titre, DateTime.Now, form.Message, null, idMoi, (int)TempData["idEq"], null);

                mes.Insert(me);
                return RedirectToAction("Equipe", "Member");
            }
            return View(form);
        }

        public ActionResult CreateSujetProjet(int id) {
            TempData["idPr"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSujetProjet(SujetForm form) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (ModelState.IsValid) {
                MessageProjetService mps = new MessageProjetService();
                MessageProjet mp = new MessageProjet(form.Titre, DateTime.Now, form.Message, null, idMoi, (int)TempData["idPr"], null);

                mps.Insert(mp);
                return RedirectToAction("Projet", "Member");
            }
            return View(form);
        }

        public ActionResult CreateSujetTache(int id) {
            TempData["idPr"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSujetTacheEquipe(SujetForm form) {
            int idMoi = (int)EmployeeSession.CurrentEmployee.Id;

            if (ModelState.IsValid) {
                MessageTacheService mts = new MessageTacheService();
                MessageTache mt = new MessageTache(form.Titre, DateTime.Now, form.Message, null, idMoi, (int)TempData["idPr"], null, null);

                mts.Insert(mt);
                return RedirectToAction("TacheEquipe", "Member");
            }
            return View(form);
        }
    }
}