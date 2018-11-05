using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _WebApp.Areas.Admin.Models.Formulaires
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Email uniquement !")]
        [MinLength(4)]
        [MaxLength(249)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email :")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Mauvais Password !")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(19)]
        public string Password { get; set; }
    }
}