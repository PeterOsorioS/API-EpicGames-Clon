using System.ComponentModel.DataAnnotations;

namespace Epic.Application.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Full name cannot be blank.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username cannot be blank.")]
        public string UserName { get;  set; }

        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage = "The email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]
        [MinLength(6, ErrorMessage = "Password length must be at least 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation cannot be blank.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Choose a valid country.")]
        public string Country { get; set; }

    }
}
