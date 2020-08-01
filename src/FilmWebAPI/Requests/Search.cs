using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;

namespace FilmWebAPI.Requests
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

        public override Task<SearchSummary> Parse(string content)
        {
            var summary = new InternalLiveSearchParser().Parse(content);
            return Task.FromResult(summary);
        }

        internal class InternalLiveSearchParser
        {
            internal SearchSummary Parse(string raw)
            {
                var rows = raw.Split("\\a").ToArray();
                var row = rows.Select(x => x.Split("\\c")).ToArray();

                var parsed = row
                    .Select(x => new SearchItemBase(ItemTypeMap.Instance[x[0].ToLower()], x))
                    .ToArray();

                var person = parsed
                    .Where(x => x.ItemType == ItemType.osoba)
                    .Select(x => new PersonSearchItem(x.ItemType, x.Raw))
                    .ToArray();

                var movies = parsed
                    .Where(x => x.ItemType == ItemType.film)
                    .Select(x => new MovieSearchItem(x.ItemType, x.Raw))
                    .ToArray();

                var serials = parsed
                    .Where(x => x.ItemType == ItemType.serial)
                    .Select(x => new SerialSearchItem(x.ItemType, x.Raw))
                    .ToArray();

                return new SearchSummary(person, movies, serials);
            }
        }
    }
}