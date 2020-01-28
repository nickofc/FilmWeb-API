using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    class GetFilmDuration : RequestBase<TimeSpan>
    {
        private const int DURATION_INDEX = 6;

        public GetFilmDuration(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<TimeSpan> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            var duration = json[DURATION_INDEX].ToString();
            var hasDuration = int.TryParse(duration, out var minutes);

            return hasDuration 
                ? TimeSpan.FromMinutes(minutes)
                : TimeSpan.Zero;
        }
    }
}
