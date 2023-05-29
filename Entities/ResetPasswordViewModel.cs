using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ResetPasswordViewModel
{
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required, MinLength(6, ErrorMessage = "Mot de passe trop court \n Au moins 6 caractères")]
        public string password { get; set; }

        [Required, Compare("password")]
        public string confirmPassword { get; set; }
        public string Code { get; set; }
    }
}
