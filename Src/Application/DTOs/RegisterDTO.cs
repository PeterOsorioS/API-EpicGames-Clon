using System.ComponentModel.DataAnnotations;

namespace Epic.Application.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Full name cannot be blank.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username cannot be blank.")]
        public string UserName { get; private set; }

        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage = "The email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]
        [MinLength(6, ErrorMessage = "The password must be a minimum of 6 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9_+&*-]+(?:\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$",
        ErrorMessage = "Email must be well-formed.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation cannot be blank.")]
        [Compare("Password", ErrorMessage = "")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Choose a valid country.")]
        public string Country { get; set; }
    }
}
