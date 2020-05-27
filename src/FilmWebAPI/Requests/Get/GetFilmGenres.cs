using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmGenres : JsonRequestBase<IReadOnlyCollection<string>, JArray>
    {
        public GetFilmGenres(ulong movieId)
        : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<string>> Parse(JArray entity)
        {
            const int FILM_GENRES_INDEX = 4;
            return entity[FILM_GENRES_INDEX].ToString().Split(',');
        }
    }
}
