using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    class Departement {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Admin { get; set; }
    }
}
