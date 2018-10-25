using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _WebApp.Models.ViewModels {
    public class MemberIndex {
        
        public Projet p { get; } = new Projet();
        public Employee e { get; } = new Employee();
        
        
        public IEnumerable<Projet> ListP { get; set; }
        public IEnumerable<Employee> ListE { get; set; }

        
        //TODO public IEnumerable<Messa>

    }
}