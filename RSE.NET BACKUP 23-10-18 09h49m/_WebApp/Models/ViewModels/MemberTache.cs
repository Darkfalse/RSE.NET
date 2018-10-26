using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _WebApp.Models.ViewModels {
    public class MemberTache {
        public TacheEquipe te { get; set; }
        public MessageTache mt { get; set; }

        public IEnumerable<MessageTache> ListM { get; set; }
        //TODO XAV equipe et employee
    }
}