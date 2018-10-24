using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class MessageProjet {
        public int? Id { get; private set; }
        public string Titre { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int? MessagePrecedent { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Projet { get; set; }

        public MessageProjet(string titre, DateTime date, string contenu, int? precedent, int idemp, int idproj) {
            Titre = titre;
            Date = date;
            Contenu = contenu;
            MessagePrecedent = precedent;
            Id_Employee = idemp;
            Id_Projet = idproj;
        }

        public MessageProjet(int? id, string titre, DateTime date, string contenu, int? precedent, int idemp, int idproj) : this(titre, date, contenu, precedent, idemp, idproj) {
            Id = id;
        }
    }
}
