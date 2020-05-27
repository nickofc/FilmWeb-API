using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    /* todo sprawdzic response */
    public class GetFilmProfessionCounts : JsonRequestBase<dynamic, JArray>
    {
        public GetFilmProfessionCounts(long movieId) : base(Signature.Create("getFilmProfessionCounts", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(JArray entity)
        {
            return default;
        }
    }
}