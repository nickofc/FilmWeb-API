using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class Search : ContentRequestBase<SearchSummary>
    {
        private const string SearchUrl = "http://www.filmweb.pl/search/live";
        
        public Search(string query)
        {
            _query = query ?? throw new ArgumentNullException(nameof(query));
        }

        private readonly string _query;

        public override HttpRequestMessage GetRequestMessage()
        {
            return new HttpRequestMessage(HttpMethod.Get, $"{SearchUrl}?q={_query}");
        }

        public override async Task<SearchSummary> Parse(string content)
        {
            return new AdvancedLiveSearchParser().Parse(content);
        }
    }
}