using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.UserInputModels
{
    public class SendEmailChangeTokenInputModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Email cannot be empty.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Confirm email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Email cannot be empty.")]
        [Compare("Email", ErrorMessage = "Emails do not match.")]
        public string? ConfirmEmail { get; set; }
    }
}