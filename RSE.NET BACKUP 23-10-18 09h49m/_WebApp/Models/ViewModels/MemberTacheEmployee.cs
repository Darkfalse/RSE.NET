using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Models;

namespace _WebApp.Models.ViewModels
{
    public class MemberTacheEmployee
    {


        public TacheEmployee te { get; set; }
        public MessageTache mt { get; set; }
        public Document doc { get; set; }

        public IDictionary<MessageTache, Employee> ListM { get; set; }
        public IEnumerable<Document> ListD { get; set; }
        
    }
}
