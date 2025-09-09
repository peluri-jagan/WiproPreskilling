using System.Security.Cryptography;
using System.Text;

namespace Jagan.EmployeeApp.Utilities
{
    public static class HashingUtil
    {
        public static string Sha256(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes); // uppercase hex
        }
    }
}
