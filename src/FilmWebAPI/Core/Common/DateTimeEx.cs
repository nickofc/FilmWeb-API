using System;

namespace FilmWebAPI.Core.Common
{
    internal static class DateTimeEx
    {
        internal static DateTime GetFromUnixTime(long ms)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(ms).DateTime;
        }
    }
}
