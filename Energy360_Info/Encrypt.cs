using System.Security.Cryptography;
using System.Text;

namespace Energy360_Info
{
    public static class Encrypt
    {
        public static string EncryptPassword(string input)
        {
            var sha256 = MD5.Create();
            byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            var passwordEncrypt = new StringBuilder();
            foreach (byte b in data)
            {
                passwordEncrypt.Append(b.ToString("x2"));
            }
            return passwordEncrypt.ToString();
        }
    }
}
