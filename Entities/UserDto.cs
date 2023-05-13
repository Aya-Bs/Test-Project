using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserDto
    {
        [Required,EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage="Mot de passe trop court \n Au moins 6 caractères")]
        public string password { get; set; } = string.Empty;
        [Required, Compare("password")]
        public string confirmPassword { get; set; } = string.Empty;
    }
}
