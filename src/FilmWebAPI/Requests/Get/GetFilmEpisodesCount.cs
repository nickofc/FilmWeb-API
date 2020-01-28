using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    class GetFilmEpisodesCount : RequestBase<int>
    {
        private const int EPISODES_COUNT_INDEX = 17;

        public GetFilmEpisodesCount(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<int> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            var parsed = int.TryParse(json[EPISODES_COUNT_INDEX].ToString(), out var episodesCount);
            return parsed ? episodesCount : default;
        }
    }
}
