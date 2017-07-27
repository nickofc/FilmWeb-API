using System;
using System.Security.Cryptography;
using System.Text;

namespace FilmWebAPI.Helpers
{
    internal static class HashHelpers
    {
        internal static string ComputeMd5(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            using (var md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                byte[] hashBytes = md5.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("x2").ToLower());
                }
                return sb.ToString();
            }
        }

        internal static string MakeSignature(string methods)
        {
            if (methods == null) throw new ArgumentNullException(nameof(methods));
            const string version = "android";
            return $"1.0,{ComputeMd5($"{methods}{version}{FilmWeb.API_KEY}")}";
        }


        internal static string ToCSV(string method, params string[] strings)
        {
            return $"{method} [{StringHelpers.ToCsv(strings)}]\n";
        }
    }
}