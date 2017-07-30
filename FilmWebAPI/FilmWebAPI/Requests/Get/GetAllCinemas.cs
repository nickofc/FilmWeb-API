using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FilmWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class GetAllCinemas : RequestBase<IEnumerable<Cinema>>
    {
        public GetAllCinemas() : base(Signature.Create("getAllCinemas", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<Cinema>> Parse(HttpResponseMessage responseMessage)
        {
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
                        Latitude = array[2].ToObject<double>(),
                        Longitude = array[3].ToObject<double>(),
                        CityId = array[4].ToObject<int>(),
                        Address = array[5].ToObject<string>(),
                        Phone = array[6].ToObject<string>(),
                    };
                });
            }
            throw new FilmWebException(FilmWebExceptionType.UnableToGetData);
        }
    }
}