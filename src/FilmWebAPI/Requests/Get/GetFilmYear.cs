using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    class GetFilmYear : RequestBase<int>
    {
        private const int FILM_YEAR_INDEX = 5;

        public GetFilmYear(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<int> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            var parsed = int.TryParse(json[FILM_YEAR_INDEX].ToString(), out var year);
            return parsed ? year : default;
        }
    }
}
