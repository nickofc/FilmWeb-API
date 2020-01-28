using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmVotesCount : RequestBase<ulong>
    {
        private const int VOTES_COUNT_INDEX = 3;

        public GetFilmVotesCount(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<ulong> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            var parsed = ulong.TryParse(json[VOTES_COUNT_INDEX].ToString(), out var votesCount);
            return parsed ? votesCount : default;
        }
    }
}
