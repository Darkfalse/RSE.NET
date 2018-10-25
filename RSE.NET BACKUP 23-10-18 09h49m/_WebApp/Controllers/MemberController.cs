using _WebApp.Infrastructure;
using _WebApp.Models.ViewModels;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _WebApp.Controllers
{
    public class MemberController : Controller
    {
        [AuthRequiredAttribute]
        public ActionResult Index()
        {
            MemberIndex mi = new MemberIndex();
            ProjetService ps = new ProjetService();
            mi.ListP = ps.GetAll();
            EmployeeService es = new EmployeeService();
            mi.ListE = es.GetAll();

            return View(mi);
        }
    }
}