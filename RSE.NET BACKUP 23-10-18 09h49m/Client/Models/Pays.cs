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
    }
}
