using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Adresse
    {
        public int? Id { get; set; }
        public string Nom_Rue { get; set; }
        public string Boite_Postal { get; set; }
        public int Id_Ville { get; set; }
    }
}
