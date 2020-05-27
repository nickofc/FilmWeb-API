using System;
using System.Security.Cryptography;
using System.Text;

namespace FilmWebAPI.Core.Security
{
    internal static class Md5
    {
        internal static string ComputeHash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            using (var md5 = MD5.Create())
            {
                var bytesToHash = Encoding.UTF8.GetBytes(value);
                var hashedBytes = md5.ComputeHash(bytesToHash);

                var sb = new StringBuilder();
                foreach (var hashedByte in hashedBytes)
                {
                    sb.Append(hashedByte.ToString("x2").ToLower());
                }

                return sb.ToString();
            }
        }
    }
}