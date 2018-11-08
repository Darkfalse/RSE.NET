using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _WebApp.Areas.Admin.Models.ViewModels {
    public class AdminDep {

        public Departement dep { get; set; }
        public Employee e { get; set; }

        public IEnumerable<Employee> ListEmpDep { get; set; } = null;
        public IEnumerable<Employee> ListOtherEmp { get; set; } = null;
    }
}