using System.ComponentModel.DataAnnotations;

namespace Application.InputModels.UserInputModels
{
    public class AuthenticateUserWithGoogleInputModel
    {
        [Required(ErrorMessage = "The Code field is required.")]
        public string? Code { get; set; }
    }
}