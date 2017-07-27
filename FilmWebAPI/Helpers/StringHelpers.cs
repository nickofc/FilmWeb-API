using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmWebAPI.Helpers
{
    public static class StringHelpers
    {
        public static string ToCsv(string[] strings)
        {
            if (strings == null) return string.Empty;
            
            var sb = new StringBuilder();
            for (int i = 0; i < strings.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(strings[i]);
            }
            return sb.ToString();
        }

        public static string to(string[] collection)
        {
            StringBuilder sb = new StringBuilder();
            if (collection != null && collection.Any())
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    sb.Append(collection[i]);
                    if (collection[i + 1] != null)
                        sb.Append(',');
                }
            }
            return sb.ToString();
        }
    }
}
