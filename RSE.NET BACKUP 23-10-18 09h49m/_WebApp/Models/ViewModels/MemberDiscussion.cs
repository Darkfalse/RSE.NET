using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Models;

namespace _WebApp.Models.ViewModels
{
    public class MemberDiscussion
    {
        public MessageEmployee messageEmployee { get; set; }
        public Employee employee { get; set; }

        public IEnumerable<MessageEmployee> ListeMessageEmployees { get; set; }


    }
}