using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Areas.Admin.Models.Formulaires {
    public class EditDepForm {

        public int Id { get; set; }

        [MaxLength(50)]
        public string Nom { get; set; }

        [MaxLength(250)]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}