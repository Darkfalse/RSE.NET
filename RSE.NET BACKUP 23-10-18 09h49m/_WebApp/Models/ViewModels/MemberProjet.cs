using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Models;

namespace _WebApp.Models.ViewModels
{
    public class MemberProjet
    {

        public Projet p { get; set; }
        public TacheEmployee t { get; }
        public Document d { get; }
        public MessageProjet mp { get; }
        public Employee chef { get; set; }


        public IEnumerable<TacheEmployee> TacheEmployees { get; set; }
        public IEnumerable<TacheEquipe> TacheEquipes { get; set; }
        public IEnumerable<Document> Documents { get; set; }
        public IEnumerable<MessageProjet> MessageProjets { get; set; }

    }
}