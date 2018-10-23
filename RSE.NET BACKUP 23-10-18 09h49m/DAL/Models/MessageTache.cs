using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class MessageTache {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int? MessagePrecedent { get; set; }
        public int Id_Employee { get; set; }
        public int? Id_Tache_Equipe { get; set; }
        public int? Id_Tache_Emplopyee { get; set; }
    }
}
