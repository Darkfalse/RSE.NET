using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Models;

namespace _WebApp.Infrastructure {
    public class EmployeeSession {

        public static Employee CurrentEmployee {
            get {
                return (Employee)HttpContext.Current.Session["User"];
            }
            set {
                HttpContext.Current.Session["User"] = value;
            }
        }
    }
}