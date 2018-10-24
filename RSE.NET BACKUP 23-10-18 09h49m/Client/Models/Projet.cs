using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class Projet {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public int? Admin { get; set; }

        public Projet(string nom, string des, DateTime debut, DateTime fin, int admin) {
            Nom = nom;
            Description = des;
            Debut = debut;
            Fin = fin;
            Admin = admin;
        }

        public Projet(int id, string nom, string des, DateTime debut, DateTime fin, int admin) : this(nom, des, debut, fin, admin) {
            Id = id;
        }
    }
}
