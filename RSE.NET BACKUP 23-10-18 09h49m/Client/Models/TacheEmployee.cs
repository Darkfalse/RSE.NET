using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class TacheEmployee {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public DateTime Final { get; set; }
        public int? TachePrecedente { get; set; }
        public int Projet { get; set; }

        public TacheEmployee(string nom, string des, DateTime debut, DateTime fin, DateTime final, int? precedente, int projet) {
            Nom = nom;
            Description = des;
            Debut = debut;
            Fin = fin;
            Final = final;
            TachePrecedente = precedente;
            Projet = projet;
        }

        public TacheEmployee(int? id, string nom, string des, DateTime debut, DateTime fin, DateTime final, int? precedente, int projet) : this(nom, des, debut, fin, final, precedente, projet) {
            Id = id;
        }
    }
}
