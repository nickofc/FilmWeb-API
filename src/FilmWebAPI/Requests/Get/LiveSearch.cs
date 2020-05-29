using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class LiveSearch : ContentRequestBase<IReadOnlyCollection<Item>>
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

        public override async Task<IReadOnlyCollection<Item>> Parse(string content)
        {
            return new AdvancedLiveSearchParser().Parse(content);
        }
    }

    public class AdvancedLiveSearchParser
    {
        public IReadOnlyCollection<Item> Parse(string content)
        {
            var rows = content.Split("\\a").ToArray();
            var row = rows.Select(x => x.Split("\\c")).ToArray();

            return row.Select(x => new Item(ItemTypeMap.Instance[x[0].ToLower()], x)).ToArray();
        }
    }
}