using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    class GetFilmVideosUrls : RequestBase<IEnumerable<string>>
    {
        public GetFilmVideosUrls(ulong movieId) 
            : base(Signature.Create("getFilmVideos", movieId, 0, 100), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<string>> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            return json.SelectMany(x => x.Where(u => u.ToString().Contains(".mp4"))).Select(x => x.ToString());
        }
    }
}
