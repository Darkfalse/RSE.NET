using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Adresse
    {
        public int? Id { get; private set; }
        public string Nom_Rue { get; set; }
        public string Boite_Postal { get; set; }
        public int Id_Ville { get; set; }

        public Adresse(string nomrue, string bp, int idville) {
            Nom_Rue = nomrue;
            Boite_Postal = bp;
            Id_Ville = idville;
        }

        public Adresse(int? id, string nomrue, string bp, int idville) : this (nomrue, bp, idville) {
            Id = id;
        }
    }
}
