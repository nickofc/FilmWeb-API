using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI.Core
{
    public static class Safe
    {
        internal static Uri ToUrl(string s)
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
