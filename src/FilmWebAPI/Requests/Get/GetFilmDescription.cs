using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmDescription : RequestBase<string>
    {
        public GetFilmDescription(ulong movieId) 
            : base(Signature.Create("getFilmDescription", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<string> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));
            var description = json.ToString().Trim("\r\n[] \"".ToCharArray()).Replace("\\\"", "\"").Replace("\\n", "\n");
            return description != "null" ? description : null;
        }
    }
}