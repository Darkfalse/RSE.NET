using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class TacheEquipe {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public DateTime Final { get; set; }
        public int? TachePrecedente { get; set; }
        public int Projet { get; set; }
    }
}
