using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    class TacheEquipe {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public DateTime Final { get; set; }
        public int? TachePrécedente { get; set; }
        public int Projet { get; set; }

        //Données de vue
        public string Statut { get; set; }
        public string NomTachePrecedente { get; set; }
    }
}
