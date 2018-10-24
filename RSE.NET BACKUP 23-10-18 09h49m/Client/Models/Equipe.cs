using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class Equipe {
        public int? Id { get; private set; }
        public string Nom { get; set; }
        public DateTime Creee { get; set; }
        public int Projet { get; set; }
    }
}
