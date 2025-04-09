using System.Text;

namespace Infrastructure.Utils
{
    public class PasswordService
    {
        public static string GenerateRandomPassword()
        {
            int defaultLength = 12;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$";
            StringBuilder res = new();
            Random rnd = new();

            while (0 < defaultLength--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}