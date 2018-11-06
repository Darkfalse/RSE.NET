using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _WebApp.Models.ViewModels {
    public class MemberEquipe {

        public Equipe eq { get; set; }
        public Employee emp { get; set; }
        public MessageEquipe msgeq { get; set; }
        public Document d { get; set; }

        public IEnumerable<Employee> ListE { get; set; }
        public IDictionary<MessageEquipe,Employee> ListMEq { get; set; }
        public IEnumerable<Document> ListD { get; set; }

    }
}