using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.UserInputModels
{
    public class SendPasswordChangeTokenInputModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Email cannot be empty.")]
        public string? Email { get; set; }
    }
}