using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI
{
    internal static class DateTimeEx
    {
        internal static DateTime GetFromUnixTime(long ms)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(ms).DateTime;
        }
    }
}
