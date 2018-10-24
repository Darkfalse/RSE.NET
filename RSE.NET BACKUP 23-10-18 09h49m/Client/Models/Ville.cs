using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class Ville {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public string Zip { get; set; }
        public int Id_Pays { get; set; }

        public Ville(string nom, string zip, int idpays) {
            Nom = nom;
            Zip = zip;
            Id_Pays = idpays;
        }

        public Ville(int id, string nom, string zip, int idpays) : this(nom, zip, idpays) {
            Id = id;
        }
    }
}
