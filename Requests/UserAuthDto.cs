using System.ComponentModel.DataAnnotations;

namespace Requests
{
    public class UserAuthDto
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;

    }
}