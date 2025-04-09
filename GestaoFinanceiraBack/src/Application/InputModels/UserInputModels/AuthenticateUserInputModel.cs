using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.UserInputModels
{
    public class AuthenticateUserInputModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Email cannot be empty.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(18, ErrorMessage = "Password cannot be longer than 18 characters.")]
        public string? Password { get; set; }
    }
}