using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.UserInputModels
{
    public class UpdateMeInputModel
    {
        [MaxLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [MinLength(1, ErrorMessage = "First name cannot be empty.")]
        public string? FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [MinLength(1, ErrorMessage = "Last name cannot be empty.")]
        public string? LastName { get; set; }

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
                PhoneNumber = PhoneNumber,
            };
        }
    }
}