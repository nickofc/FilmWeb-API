using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmDuration : JsonRequestBase<TimeSpan, JArray>
    {

        public GetFilmDuration(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<TimeSpan> Parse(JArray entity)
        {
            const int DURATION_INDEX = 6;

            var duration = entity[DURATION_INDEX].ToString();
            var hasDuration = int.TryParse(duration, out var minutes);

            return hasDuration
                ? TimeSpan.FromMinutes(minutes)
                : TimeSpan.Zero;
        }
    }
}
