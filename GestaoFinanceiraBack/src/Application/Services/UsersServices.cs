using Core.Repositories;
using Application.InputModels.UserInputModels;
using Application.ViewModels;
using Application.Exceptions;
using Application.Validators;
using Core.Entities;
using Core.Enums;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace Application.Services
{
    public class UsersServices(IUsersRepository usersRepository, IConfiguration configuration) : IUsersServices
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly IConfiguration _configuration = configuration;

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = await _usersRepository.GetAllAsync();
            return users.Select(UserViewModel.FromEntity);
        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            var user = await _usersRepository.GetByIdAsync(id) ?? throw new NotFoundException("User not found");
            return UserViewModel.FromEntity(user);
        }

        public async Task<UserViewModel> GetMeAsync(ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");
            return UserViewModel.FromEntity(user);
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            var user = await _usersRepository.GetByEmailAsync(email);
            return user != null;
        }

        public async Task<bool> CheckPhoneAsync(string phone)
        {
            var user = await _usersRepository.GetByPhoneAsync(phone);
            return user != null;
        }

        public async Task<bool> CheckPasswordResetTokenAsync(string key, string token)
        {
            var userId = HashService.Decrypt(key, _configuration);

            if (userId == null) return false;

            var user = await _usersRepository.GetByIdAsync(Guid.Parse(userId));

            if (user == null) return false;

            var result = await _usersRepository.CheckPasswordResetTokenAsync(user, token);
            return result;
        }

        public async Task<TokenViewModel> RegisterMeAsync(RegisterMeInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var userExists = await _usersRepository.GetByEmailAsync(inputModel.Email!);

            if (userExists != null)
                throw new ConflictException("User already exists!");

            var generatedUserName = string.Concat(inputModel.Email!.Split('@')[0], Guid.NewGuid().ToString().AsSpan(0, 5));
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(inputModel.Password!);

            var defaultRole = RoleExtension.ToRole("Owner");
            var role = await _usersRepository.GetRoleByNameAsync(defaultRole) ?? throw new NotFoundException("Role not found");

            var user = new User
            {
                FirstName = inputModel.FirstName!,
                LastName = inputModel.LastName!,
                Email = inputModel.Email!,
                NormalizedEmail = inputModel.Email!.ToUpper(),
                PhoneNumber = inputModel.PhoneNumber!,
                UserName = generatedUserName,
                NormalizedUserName = generatedUserName.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _usersRepository.AddAsync(user, role);
            var token = JwtService.Generate(user, _configuration);

            return new TokenViewModel(token);
        }

        public async Task<UserViewModel> RegisterAsync(RegisterUserInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var userExists = await _usersRepository.GetByEmailAsync(inputModel.Email!);

            if (userExists != null)
                throw new ConflictException("User already exists!");

            var generatedUserName = string.Concat(inputModel.Email!.Split('@')[0], Guid.NewGuid().ToString().AsSpan(0, 5));
            var generatedPassword = PasswordService.GenerateRandomPassword();
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(generatedPassword);

            var role = await _usersRepository.GetRoleByNameAsync(inputModel.Role) ?? throw new NotFoundException("Role not found");

            var user = new User
            {
                FirstName = inputModel.FirstName!,
                LastName = inputModel.LastName!,
                Email = inputModel.Email!,
                NormalizedEmail = inputModel.Email!.ToUpper(),
                PhoneNumber = inputModel.PhoneNumber!,
                UserName = generatedUserName,
                PasswordHash = passwordHash,
                NormalizedUserName = generatedUserName.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _usersRepository.AddAsync(user, role);

            // TODO: Send email with generatedPassword

            return UserViewModel.FromEntity(user);
        }

        public async Task<UserViewModel> UpdateAsync(Guid id, UpdateUserInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var user = await _usersRepository.GetByIdAsync(id) ?? throw new NotFoundException("User not found");

            user.Update(
                firstName: inputModel.FirstName,
                lastName: inputModel.LastName,
                phoneNumber: inputModel.PhoneNumber
            );

            IdentityRole<Guid>? role = await _usersRepository.GetRoleByNameAsync(inputModel.Role);

            await _usersRepository.UpdateAsync(user, role);

            return UserViewModel.FromEntity(user);
        }

        public async Task<UserViewModel> UpdateMeAsync(UpdateMeInputModel inputModel, ClaimsPrincipal actionUser)
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            user.Update(
                firstName: inputModel.FirstName,
                lastName: inputModel.LastName,
                phoneNumber: inputModel.PhoneNumber
            );

            await _usersRepository.UpdateAsync(user);

            return UserViewModel.FromEntity(user);
        }

        public async Task ChangePasswordAsync(ChangeUserPasswordInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var userIdEncrypted = inputModel.Key!;
            var userId = HashService.Decrypt(userIdEncrypted, _configuration) ?? throw new NotFoundException("User not found");
            var user = await _usersRepository.GetByIdAsync(Guid.Parse(userId)) ?? throw new NotFoundException("User not found");

            _ = await _usersRepository.ChangePasswordAsync(user, inputModel.Password!, inputModel.Token!) ?? throw new BadRequestException("Invalid token", []);

            return;
        }

        public async Task<UserViewModel> ChangeEmailAsync(ChangeUserEmailInputModel inputModel, ClaimsPrincipal actionUser)
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var updatedUser = await _usersRepository.ChangeEmailAsync(user, inputModel.Email!, inputModel.Token!) ?? throw new BadRequestException("Invalid token", []);

            return UserViewModel.FromEntity(updatedUser);
        }

        public async Task<UserViewModel> DeleteAsync(Guid id)
        {
            var user = await _usersRepository.GetByIdAsync(id) ?? throw new NotFoundException("User not found");

            await _usersRepository.DeleteAsync(user);

            return UserViewModel.FromEntity(user);
        }

        public async Task SendEmailChangeTokenAsync(SendEmailChangeTokenInputModel inputModel, ClaimsPrincipal actionUser)
        {
            InputModelValidator.Validate(inputModel);

            var userAlreadyExists = await _usersRepository.GetByEmailAsync(inputModel.Email!);

            if (userAlreadyExists != null)
                throw new ConflictException("Email already in use");

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var token = await _usersRepository.GenerateEmailChangeTokenAsync(user, inputModel.Email!);
            var tokenUrlEncoded = HttpUtility.UrlEncode(token);

            Console.WriteLine(tokenUrlEncoded);

            // TODO: Send email with token (eg. frontend_url/change-email?token=tokenUrlEncoded)
        }

        public async Task SendPasswordResetTokenAsync(SendPasswordChangeTokenInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var user = await _usersRepository.GetByEmailAsync(inputModel.Email!);

            if (user == null) return;

            var userId = user.Id.ToString();

            var token = await _usersRepository.GeneratePasswordChangeTokenAsync(user);
            var userIdEncrypted = HashService.Encrypt(userId, _configuration);

            var tokenUrlEncoded = HttpUtility.UrlEncode(token);
            var userIdEncryptedUrlEncoded = HttpUtility.UrlEncode(userIdEncrypted);

            Console.WriteLine(tokenUrlEncoded, userIdEncryptedUrlEncoded);

            // TODO: Send email with token and userIdEncrypted (eg. frontend_url/change-password?token=tokenUrlEncoded&key=userIdEncryptedUrlEncoded)
        }

        public async Task<TokenViewModel> AuthenticateAsync(AuthenticateUserInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var user = await _usersRepository.GetByEmailAsync(inputModel.Email!) ?? throw new BadRequestException("Email or password incorrect", []);

            if (!BCrypt.Net.BCrypt.Verify(inputModel.Password!, user.PasswordHash))
                throw new BadRequestException("Email or password incorrect", []);

            var token = JwtService.Generate(user, _configuration);

            return new TokenViewModel(token);
        }

        public async Task<TokenViewModel> AuthenticateWithGoogleAsync(AuthenticateUserWithGoogleInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var userEmail = await GoogleService.VerifyTokenAsync(inputModel.Code!, _configuration) ?? throw new BadRequestException("Invalid token", []);
            var user = await _usersRepository.GetByEmailAsync(userEmail) ?? throw new BadRequestException("Email not found", []);

            var token = JwtService.Generate(user, _configuration);

            return new TokenViewModel(token);
        }
    }
}