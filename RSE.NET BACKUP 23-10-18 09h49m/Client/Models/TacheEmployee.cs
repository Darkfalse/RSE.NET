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
    }
}
