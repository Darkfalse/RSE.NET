using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class Pays {
        public int? Id { get; private set; }
        public int Code { get; set; }
        public string Alpha2 { get; set; }
        public string Alpha3 { get; set; }
        public string Nom_EN { get; set; }
        public string Nom_FR { get; set; }

        public Pays(int code, string a2, string a3, string nomfr, string nomen) {
            Code = code;
            Alpha2 = a2;
            Alpha3 = a3;
            Nom_EN = nomen;
            Nom_FR = nomfr;
        }

        public Pays(int? id, int code, string a2, string a3, string nomfr, string nomen) : this(code, a2, a3, nomfr, nomen) {
            Id = id;
        }
    }
}
