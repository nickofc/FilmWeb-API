using System;

namespace FilmWebAPI.Core.Common
{
    internal static class Parse
    {
        internal static Uri Url(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            try
            {
                return new Uri(s);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
