using System.Collections.Generic;
using System.Linq;

namespace FilmWebAPI.Helpers
{
    public static class QueryHelpers
    {
        public static string CreateQuery(string baseUrl, ICollection<KeyValuePair<string, string>> collection)
        {
            return Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(baseUrl, collection.ToDictionary(pair => pair.Key, pair => pair.Value));
        }
    }
}