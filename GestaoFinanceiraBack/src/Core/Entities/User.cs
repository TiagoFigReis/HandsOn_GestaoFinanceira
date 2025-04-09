using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public UserStatus Status { get; set; } = UserStatus.Active;

        [NotMapped]
        public string? RoleName { get; set; }
        [NotMapped]
        public string? StatusName { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            NormalizedEmail = email.ToUpper();
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = false;
            CreatedAt = DateTime.Now;
        }

        public string FullName => $"{FirstName} {LastName}";

        public void Update(
            string? firstName = null,
            string? lastName = null,
            string? email = null,
            string? phoneNumber = null,
            UserStatus? status = null
        )
        {
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            Email = email ?? Email;
            NormalizedEmail = email?.ToUpper() ?? NormalizedEmail;
            PhoneNumber = phoneNumber ?? PhoneNumber;
            Status = status ?? Status;

            UpdatedAt = DateTime.Now;
        }
    }
}