using System.ComponentModel.DataAnnotations;

namespace Epic.Application.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage = "The email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]
        [MinLength(6, ErrorMessage = "The password must be a minimum of 6 characters.")]
        public string Password { get; set; }
    }
}
