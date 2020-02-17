using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 2, ErrorMessage = "You must specify a password between 2 and 8 characters")]
        public string Password { get; set; }
    }
}