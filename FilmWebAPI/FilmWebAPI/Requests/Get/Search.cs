using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FilmWebAPI.Models;

namespace FilmWebAPI.Requests.Get
{
    public class Search : RequestBase<dynamic>
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


        private readonly string _query;
        public Search(string query)
        {
            _query = query;
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }

        public override HttpRequestMessage GetRequestMessage()
        {
            var http = new HttpRequestMessage(HttpMethod.Get, $"{SEARCH_URL}?q={_query}");

            return base.GetRequestMessage();
        }

    }
}
