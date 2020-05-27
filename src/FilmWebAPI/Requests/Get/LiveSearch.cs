using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class LiveSearch : ContentRequestBase<ulong?>
    {
        private const string SEARCH_URL = "http://www.filmweb.pl/search/live";
        private readonly string _query;

        public LiveSearch(string query)
        {
            _query = query ?? throw new ArgumentNullException(nameof(query));
        }
        public override HttpRequestMessage GetRequestMessage()
        {
            return new HttpRequestMessage(HttpMethod.Get, $"{SEARCH_URL}?q={_query}");
        }

        public override async Task<ulong?> Parse(string content)
        {
            const int MOVIE_ID_INDEX = 1;
            foreach (var item in content.Split(new[] { "\\a" }, StringSplitOptions.None))
            {
                var oneResult = item.Split(new[] { "\\c" }, StringSplitOptions.None);
                var itemType = oneResult[0];
                if (itemType == "f" || itemType == "s")
                {
                    return ulong.Parse(oneResult[MOVIE_ID_INDEX]);
                }
            }
            return null;
        }

    }

    public class SearchBody
    {
        public List<string> Films { get; }
        public List<string> Serials { get; }
        public List<string> Persons { get; }
    }

    public class LiveSearchAdvanced
    {

    }
}