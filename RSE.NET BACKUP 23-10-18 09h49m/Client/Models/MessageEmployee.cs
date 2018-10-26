using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class MessageEmployee
    {
        public int? Id { get; private set; }
        public string Titre { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }
        public int? MessagePrecedent { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Destinataire { get; set; }

        public MessageEmployee() {

        }

        public MessageEmployee(string titre, DateTime date, string contenu, int? precedent, int idemp, int iddest) {
            Titre = titre;
            Date = date;
            Contenu = contenu;
            MessagePrecedent = precedent;
            Id_Employee = idemp;
            Id_Destinataire = iddest;
        }

        public MessageEmployee(int? id, string titre, DateTime date, string contenu, int? precedent, int idemp, int iddest) : this(titre, date, contenu, precedent, idemp, iddest) {
            Id = id;
        }
    }
}
