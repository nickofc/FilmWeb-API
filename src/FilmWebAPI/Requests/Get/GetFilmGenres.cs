using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

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
