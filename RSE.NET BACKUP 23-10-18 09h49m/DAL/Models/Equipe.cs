using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    class Equipe {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public DateTime Creee { get; set; }
        public string NomProjet { get; set; }

        //Données de vue
        public string NomManager { get; set; }
        public string PrenomManager { get; set; }
    }
}
