using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmSeasonsCount : RequestBase<int>
    {
        private const int SEASONS_COUNT_INDEX = 16;

        public GetFilmSeasonsCount(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<int> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetRawBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            var parsed = int.TryParse(json[SEASONS_COUNT_INDEX].ToString(), out var seasonsCount);
            return parsed ? seasonsCount : default;
        }
    }
}
