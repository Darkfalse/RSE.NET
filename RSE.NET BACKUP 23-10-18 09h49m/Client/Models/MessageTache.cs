using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class MessageTache {
        public int? Id { get; private set; }
        public string Titre { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int? MessagePrecedent { get; set; }
        public int Id_Employee { get; set; }
        public int? Id_Tache_Equipe { get; set; }
        public int? Id_Tache_Employee { get; set; }

        public MessageTache() {

        }

        public MessageTache(string titre, DateTime date, string contenu, int? precedent, int idemp, int? idtaeq, int? idtaemp) {
            Titre = titre;
            Date = date;
            Contenu = contenu;
            MessagePrecedent = precedent;
            Id_Employee = idemp;
            Id_Tache_Equipe = idtaeq;
            Id_Tache_Employee = idtaemp;
        }

        public MessageTache(int? id, string titre, DateTime date, string contenu, int? precedent, int idemp, int? idtaeq, int? idtaemp) : this(titre, date, contenu, precedent, idemp, idtaeq, idtaemp) {
            Id = id;
        }
    }
}
