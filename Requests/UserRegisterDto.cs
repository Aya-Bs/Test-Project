using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requests
{
    public class 
        UserRegisterDto
    {
        [Required]
        public string nom { get; set; } = string.Empty;
        [Required]
        public string prenom { get; set; } = string.Empty;

        public long telephone { get; set; }

        public string adresse { get; set; } = string.Empty;
        [Required,EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage="Mot de passe trop court \n Au moins 6 caractères")]
        public string password { get; set; } = string.Empty;
        [Required, Compare("password")]
        public string confirmPassword { get; set; } = string.Empty;
    }
}
