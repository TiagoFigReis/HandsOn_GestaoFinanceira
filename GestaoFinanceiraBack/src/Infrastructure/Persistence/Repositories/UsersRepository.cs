using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UsersRepository(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, UsersDbContext context) : IUsersRepository
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager = roleManager;
        private readonly UsersDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                user.RoleName = roles.FirstOrDefault(r => userRoles.Contains(r.Name!))?.Name!;
                user.StatusName = StatusExtension.ToFriendlyString(user.Status);
            }

            return users;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            user.RoleName = roles.FirstOrDefault()!;
            user.StatusName = StatusExtension.ToFriendlyString(user.Status);

            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            user.RoleName = roles.FirstOrDefault()!;
            user.StatusName = StatusExtension.ToFriendlyString(user.Status);

            return user;
        }

        public async Task<User?> GetByPhoneAsync(string phoneNumber)
        {
            var users = await _userManager.Users.ToListAsync();
            var user = users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);

            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            user.RoleName = roles.FirstOrDefault()!;
            user.StatusName = StatusExtension.ToFriendlyString(user.Status);

            return user;
        }

        public async Task<User> AddAsync(User user, IdentityRole<Guid> role)
        {
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded) throw new Exception("Failed to create user");

            await _userManager.AddToRoleAsync(user, role.Name!);

            user.RoleName = role.Name!;
            user.StatusName = StatusExtension.ToFriendlyString(user.Status);

            return user;
        }

        public async Task<User> UpdateAsync(User user, IdentityRole<Guid>? role)
        {
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) throw new Exception("Failed to update user");

            if (role != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRoleAsync(user, role.Name!);
            }

            user.RoleName = role?.Name!;
            user.StatusName = StatusExtension.ToFriendlyString(user.Status);

            return user;
        }

        public async Task<User> DeleteAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded) throw new Exception("Failed to delete user");

            return user;
        }

        public async Task<IdentityRole<Guid>?> GetRoleByNameAsync(UserRole roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName.ToString());
            return role;
        }

        public async Task<IEnumerable<IdentityRole<Guid>>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<string> GenerateEmailChangeTokenAsync(User user, string newEmail)
        {
            var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            return token;
        }

        public async Task<string> GeneratePasswordChangeTokenAsync(User user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }


        public async Task<User?> ChangeEmailAsync(User user, string newEmail, string token)
        {
            var result = await _userManager.ChangeEmailAsync(user, newEmail, token);

            if (!result.Succeeded) return null;

            return user;
        }

        public async Task<User?> ChangePasswordAsync(User user, string newPassword, string token)
        {
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded) return null;

            return user;
        }

        public async Task<bool> CheckPasswordResetTokenAsync(User user, string token)
        {
            var isValid = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
            return isValid;
        }

        public async Task<bool> CheckEmailChangeTokenAsync(User user, string token)
        {
            var isValid = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.EmailConfirmationTokenProvider, "ChangeEmail", token);
            return isValid;
        }
    }
}