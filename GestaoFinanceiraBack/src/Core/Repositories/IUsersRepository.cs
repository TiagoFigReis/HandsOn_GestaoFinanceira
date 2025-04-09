using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByPhoneAsync(string phone);

        Task<User> AddAsync(User user, IdentityRole<Guid> role);
        Task<User> UpdateAsync(User user, IdentityRole<Guid>? role = null);
        Task<User> DeleteAsync(User user);

        Task<IdentityRole<Guid>?> GetRoleByNameAsync(UserRole roleName);
        Task<IEnumerable<IdentityRole<Guid>>> GetAllRolesAsync();

        Task<string> GenerateEmailChangeTokenAsync(User user, string newEmail);
        Task<string> GeneratePasswordChangeTokenAsync(User user);

        Task<User?> ChangeEmailAsync(User user, string newEmail, string token);
        Task<User?> ChangePasswordAsync(User user, string newPassword, string token);

        Task<bool> CheckPasswordResetTokenAsync(User user, string token);
        Task<bool> CheckEmailChangeTokenAsync(User user, string token);
    }
}