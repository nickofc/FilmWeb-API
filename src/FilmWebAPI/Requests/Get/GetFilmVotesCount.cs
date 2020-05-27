using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmVotesCount : RequestBase<ulong>
    {
        private const int VOTES_COUNT_INDEX = 3;

        public GetFilmVotesCount(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<ulong> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetRawBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            var parsed = ulong.TryParse(json[VOTES_COUNT_INDEX].ToString(), out var votesCount);
            return parsed ? votesCount : default;
        }
    }
}
