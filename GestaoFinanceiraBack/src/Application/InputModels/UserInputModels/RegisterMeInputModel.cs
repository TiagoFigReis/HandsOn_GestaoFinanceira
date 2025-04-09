using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.UserInputModels
{
    public class RegisterMeInputModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [MinLength(1, ErrorMessage = "First name cannot be empty.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [MinLength(1, ErrorMessage = "Last name cannot be empty.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(18, ErrorMessage = "Password cannot be longer than 18 characters.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [MinLength(1, ErrorMessage = "Email cannot be empty.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [MinLength(1, ErrorMessage = "Phone number cannot be empty.")]
        [MaxLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        public string? PhoneNumber { get; set; }

        public User ToEntity()
        {
            return new User()
            {
                FirstName = FirstName!,
                LastName = LastName!,
                Email = Email,
                NormalizedEmail = Email!.ToUpper(),
                PhoneNumber = PhoneNumber,
            };
        }
    }
}