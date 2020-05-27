using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using FilmWebAPI.Models;

namespace FilmWebAPI.Requests.Get
{
    /* todo: testy */
    public class GetFilmInfoFull : JsonRequestBase<FilmInfo, JArray>
    {

        public GetFilmInfoFull(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<FilmInfo> Parse(JArray entity)
        {
            const int FILM_GENRES_INDEX = 4;
            const int EPISODES_COUNT_INDEX = 17;

            const int PREMIERE_WORLD_INDEX = 13;
            const int PREMIERE_COUNTRY_INDEX = 14;

            const int COUNTRIES_PRODUCTION = 18;

            const int SEASONS_COUNT_INDEX = 16;

            const int SHORT_DESCRIPTION_INDEX = 19;

            return new FilmInfo
            {
                PolishTitle = entity[0].ToObject<string>(),
                EnglishTitle = entity[1].ToObject<string>(),
                Score = entity[2].ToObject<double>(),
                Votes = entity[3].ToObject<long>(),
                Categories = entity[4].ToObject<string>(),
                Duration = TimeSpan.FromMinutes(entity[6].ToObject<int>())
            };
        }

    //    var world = json[PREMIERE_WORLD_INDEX].ToString();
    //    var country = json[PREMIERE_COUNTRY_INDEX].ToString();

    //    var premiers = new List<KeyValuePair<string, DateTime>>();

    //        if (!string.IsNullOrWhiteSpace(world))
    //    {
    //        premiers.Add(GetDictionary("world", world));
    //    }

    //    if (!string.IsNullOrWhiteSpace(country))
    //    {
    //        premiers.Add(GetDictionary("country", country));
    //    }

    //    return premiers;
    //}

    //private KeyValuePair<string, DateTime> GetDictionary(string where, string date)
    //{
    //var hasDate = DateTime.TryParse(date, out var dateTime);
    //    if (!hasDate)
    //{
    //    dateTime = DateTime.MinValue;
    //}

    //return new KeyValuePair<string, DateTime>(where, dateTime);
    //}
    }
}
