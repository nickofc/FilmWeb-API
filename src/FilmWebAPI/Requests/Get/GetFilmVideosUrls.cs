using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmVideosUrls : RequestBase<IEnumerable<string>>
    {
        public GetFilmVideosUrls(ulong movieId)
            : base(Signature.Create("getFilmVideos", movieId, 0, 100), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<string>> Parse(HttpResponseMessage responseMessage)
        {
            // doesn't work since last api changes - maybe it's possible to fix
            var jsonBody = await base.GetRawBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            return json.SelectMany(x => x.Where(u => u.ToString().Contains(".mp4"))).Select(x => x.ToString());
        }
    }
}
