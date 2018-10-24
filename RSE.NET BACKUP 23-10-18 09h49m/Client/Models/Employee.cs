using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
     public class Employee {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string RegNat { get; set; }
        public int? Adresse { get; set; }
        public DateTime HireDate { get; set; }
        public string Tel { get; set; }
        public int? Coordonnee { get; set; }
    }
}
