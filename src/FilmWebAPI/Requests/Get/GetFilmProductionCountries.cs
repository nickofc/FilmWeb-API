using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    class GetFilmProductionCountries : RequestBase<IEnumerable<string>>
    {
        private const int COUNTRIES_PRODUCTION = 18;

        public GetFilmProductionCountries(ulong movieId) 
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<string>> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            return json[COUNTRIES_PRODUCTION].ToString().Split(',').Select(x => x.TrimStart());
        }
    }
}
