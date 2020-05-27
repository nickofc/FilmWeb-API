using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class Search : RequestBase<ulong?>
    {
        private const string CINEMA_TYPE = "c";
        private const string FILM_TYPE = "f";
        private const string GAME_TYPE = "g";
        private const string NULL_STRING = "null";
        private const string PERSON_TYPE = "p";
        private const string RECORD_FIELD_SEPARATOR = "\\\\c";
        private const string RECORD_SEPARATOR = "\\\\a";
        private const string SEARCH_URL = "http://www.filmweb.pl/search/live";
        private const string SERIAL_TYPE = "s";
        private const int THUMB_SIZE_FILM = 4;
        private const int THUMB_SIZE_PERSON = 2;

        private readonly string _movieTitle;

        public Search(string movieTitle) : base(Signature.Create("search", movieTitle), FilmWebHttpMethod.Get)
        {
            _movieTitle = movieTitle;
        }

        public override async Task<ulong?> Parse(HttpResponseMessage responseMessage)
        {
            if (responseMessage == null)
            {
                throw new ArgumentNullException(nameof(responseMessage));
            }

            var content = await responseMessage.Content.ReadAsStringAsync();

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

        public override HttpRequestMessage GetRequestMessage()
        {
            var http = new HttpRequestMessage(HttpMethod.Get, $"{SEARCH_URL}?q={_movieTitle}");
            return http;
        }
    }
}