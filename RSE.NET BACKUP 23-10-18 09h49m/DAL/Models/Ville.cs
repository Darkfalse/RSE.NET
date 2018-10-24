using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class Ville {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Zip { get; set; }
        public int Id_Pays { get; set; }
    }
}
