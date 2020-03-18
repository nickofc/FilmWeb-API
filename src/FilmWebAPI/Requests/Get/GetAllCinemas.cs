using FilmWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetAllCinemas : RequestBase<IReadOnlyCollection<Cinema>>
    {
        public GetAllCinemas() : base(Signature.Create("getAllCinemas", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<Cinema>> Parse(HttpResponseMessage responseMessage)
        {
            // doesn't work since last api changes - maybe it's possible to fix
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (content.StartsWith("ok"))
            {
                var jsonBody = content.Remove(0, 3);
                var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

                return json.Skip(1).Select(token =>
                {
                    var array = token as JArray;
                    if (array == null) return null;

                    return new Cinema
                    {
                        Id = array[0].ToObject<int>(),
                        Name = array[1].ToObject<string>(),
                        Latitude = array[2].Value<double?>(),
                        Longitude = array[3].Value<double?>(),
                        CityId = array[4].ToObject<int>(),
                        Address = array[5].ToObject<string>(),
                        Phone = array[6].ToObject<string>(),
                    };
                }).ToArray();
            }
            throw new FilmWebException(FilmWebExceptionType.UnableToGetData);
        }
    }
}