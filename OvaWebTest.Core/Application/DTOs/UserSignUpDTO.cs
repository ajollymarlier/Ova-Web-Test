using System.ComponentModel.DataAnnotations;

namespace OvaWebTest.Application.DTOs
{
    public class UserSignUpDTO
    {
        private const string PasswordErrorMessage = "The password and confirmation password do not match.";

        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = PasswordErrorMessage)]
        public string ConfirmPassword { get; set; }
    }
}
