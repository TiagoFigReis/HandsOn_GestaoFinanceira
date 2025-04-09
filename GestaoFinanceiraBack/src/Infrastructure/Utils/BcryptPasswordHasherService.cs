using BCrypt.Net;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Utils
{
    public class BcryptPasswordHasherService<TUser> : IPasswordHasher<TUser> where TUser : class
    {
        public string HashPassword(TUser user, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(
                password,
                BCrypt.Net.BCrypt.GenerateSalt(12)
            );
        }

        public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}


