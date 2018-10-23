using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    class Employee {
        public int? Id { get; set; }
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

        //Données de vues
        public string Rue { get; set; }
        public string BoitePostale { get; set; }
        public string Ville { get; set; }
        public int? Zip { get; set; }
        public string Pays { get; set; }
    }
}
