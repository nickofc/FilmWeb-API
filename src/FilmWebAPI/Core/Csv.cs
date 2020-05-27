using System.Text;

namespace FilmWebAPI.Core
{
    internal static class Csv
    {
        internal static string To(object[] arguments)
        {
            if (arguments == null || arguments.Length <= 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < arguments.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(arguments[i]);
            }
            return sb.ToString();
        }
    }
}