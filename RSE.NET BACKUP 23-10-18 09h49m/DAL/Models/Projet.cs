using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    class Projet {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }

        //Données de vues
        public string NomManager { get; set; }
        public string PrenomManager { get; set; }
    }
}
