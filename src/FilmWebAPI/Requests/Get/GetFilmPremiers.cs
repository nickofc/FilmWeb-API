﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    class GetFilmPremieres : RequestBase<IEnumerable<KeyValuePair<string, DateTime>>>
    {
        private const int PREMIERE_WORLD_INDEX = 13;
        private const int PREMIERE_COUNTRY_INDEX = 14;

        public GetFilmPremieres(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<KeyValuePair<string, DateTime>>> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            var world = json[PREMIERE_WORLD_INDEX].ToString();
            var country = json[PREMIERE_COUNTRY_INDEX].ToString();

            var premiers = new List<KeyValuePair<string, DateTime>>();

            if (!string.IsNullOrWhiteSpace(world))
            {
                premiers.Add(GetDictionary("world", world));
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                premiers.Add(GetDictionary("country", country));
            }

            return premiers;
        }

        private KeyValuePair<string, DateTime> GetDictionary(string where, string date)
        {
            var hasDate = DateTime.TryParse(date, out var dateTime);
            if (!hasDate)
            {
                dateTime = DateTime.MinValue;
            }

            return new KeyValuePair<string, DateTime>(where, dateTime);
        }
    }
}
