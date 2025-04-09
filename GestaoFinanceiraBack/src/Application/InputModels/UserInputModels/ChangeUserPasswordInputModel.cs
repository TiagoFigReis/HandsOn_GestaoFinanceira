using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.UserInputModels
{
    public class ChangeUserPasswordInputModel
    {
        [Required(ErrorMessage = "Key is required.")]
        public string? Key { get; set; }

        [Required(ErrorMessage = "Token is required.")]
        public string? Token { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(18, ErrorMessage = "Password cannot be longer than 18 characters.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [MaxLength(18, ErrorMessage = "Confirm password cannot be longer than 18 characters.")]
        [MinLength(8, ErrorMessage = "Confirm password must be at least 8 characters long.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}