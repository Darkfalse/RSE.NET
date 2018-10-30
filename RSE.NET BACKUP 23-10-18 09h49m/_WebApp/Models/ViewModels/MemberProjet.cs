using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Models;

namespace _WebApp.Models.ViewModels
{
    public class MemberProjet
    {

        public Projet p { get; set; } = new Projet();
        public TacheEmployee t { get; } = new TacheEmployee();
        public Document d { get; } = new Document();
        public MessageProjet mp { get; } = new MessageProjet();
        public Employee chef { get; set; }


        public IEnumerable<TacheEmployee> TacheEmployees { get; set; }
        public IEnumerable<TacheEquipe> TacheEquipes { get; set; }
        public IEnumerable<Document> Documents { get; set; }
        public IEnumerable<MessageProjet> MessageProjets { get; set; }

    }
}