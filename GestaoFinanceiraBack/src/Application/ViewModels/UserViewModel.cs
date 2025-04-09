using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        public static UserViewModel FromEntity(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Role = user.RoleName!,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Status = user.StatusName!
            };
        }
    }
}