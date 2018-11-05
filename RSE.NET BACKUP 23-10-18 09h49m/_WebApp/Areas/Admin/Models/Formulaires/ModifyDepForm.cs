using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Areas.Admin.Models.Formulaires {
    public class ModifyDepForm {

        [MaxLength(50)]
        public string Nom { get; set; }

        [MaxLength(250)]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}