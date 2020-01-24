using System;
using System.Collections.Generic;
using System.Web;

namespace FilmWebAPI
{
    internal static class Url
    {
        internal static string Create(string baseUrl, ICollection<KeyValuePair<string, string>> arguments)
        {
            var builder = new UriBuilder(baseUrl);
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var argument in arguments)
            {
                query.Add(argument.Key, argument.Value);
            }

            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}