using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FilmWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class GetAllCinemas : RequestBase<IEnumerable<Cinema>>
    {
        public GetAllCinemas() : base(Signature.Create("getAllCinemas", "-1"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<Cinema>> Parse(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (content.StartsWith("ok"))
            {
                var jsonBody = content.Remove(0, 3).Replace("t:43200", string.Empty);
                var json = JsonConvert.DeserializeObject<JArray>(jsonBody);

                IEnumerable<Cinema> GetCinemas(JArray o)
                {
                    for (int i = 1; i < o.Count; i++)
                    {
                        yield return new Cinema
                        {
                            Id = o[i][0].Value<int>(),
                            Name = o[i][1].Value<string>(),
                            Latitude = o[i][2].Value<double>(),
                            Longitude = o[1][3].Value<double>(),
                            CityId = o[i][4].Value<int>(),
                            Address = o[i][5].Value<string>(),
                            Phone = o[i][6].Value<string>(),
                        };
                    }
                }

                return GetCinemas(json);
            }


            throw new FilmWebException(FilmWebExceptionType.UnableToGetData);
        }
    }
}