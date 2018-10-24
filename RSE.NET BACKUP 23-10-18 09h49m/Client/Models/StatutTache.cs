using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class StatutTache
    {
        public int? Id { get; private set; }
        public string NomStatut { get; set; }

        public StatutTache(string nom) {
            NomStatut = nom;
        }

        public StatutTache(int id, string nom) : this(nom) {
            Id = id;
        }
    }
}
