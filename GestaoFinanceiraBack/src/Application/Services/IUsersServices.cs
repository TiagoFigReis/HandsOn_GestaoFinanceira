using System.Security.Claims;
using Application.InputModels.UserInputModels;
using Application.ViewModels;

namespace Application.Services
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(Guid id);
        Task<UserViewModel> GetMeAsync(ClaimsPrincipal actionUser);
        Task<bool> CheckEmailAsync(string email);
        Task<bool> CheckPhoneAsync(string phone);
        Task<bool> CheckPasswordResetTokenAsync(string key, string token);

        Task<TokenViewModel> RegisterMeAsync(RegisterMeInputModel inputModel);
        Task<UserViewModel> RegisterAsync(RegisterUserInputModel inputModel);
        Task<UserViewModel> UpdateAsync(Guid id, UpdateUserInputModel inputModel);
        Task<UserViewModel> UpdateMeAsync(UpdateMeInputModel inputModel, ClaimsPrincipal actionUser);
        Task ChangePasswordAsync(ChangeUserPasswordInputModel inputModel);
        Task<UserViewModel> ChangeEmailAsync(ChangeUserEmailInputModel inputModel, ClaimsPrincipal actionUser);
        Task<UserViewModel> DeleteAsync(Guid id);

        Task SendEmailChangeTokenAsync(SendEmailChangeTokenInputModel inputModel, ClaimsPrincipal actionUser);
        Task SendPasswordResetTokenAsync(SendPasswordChangeTokenInputModel inputModel);

        Task<TokenViewModel> AuthenticateAsync(AuthenticateUserInputModel inputModel);
        Task<TokenViewModel> AuthenticateWithGoogleAsync(AuthenticateUserWithGoogleInputModel inputModel);
    }
}