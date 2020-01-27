using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    class GetFilmShortDescription : RequestBase<string>
    {
        private const int SHORT_DESCRIPTION_INDEX = 19;

        public GetFilmShortDescription(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<string> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            return json[SHORT_DESCRIPTION_INDEX].ToString();
        }
    }
}
