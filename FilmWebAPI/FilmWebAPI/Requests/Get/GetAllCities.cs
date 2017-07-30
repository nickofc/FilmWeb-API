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
    public class GetAllCities : RequestBase<IEnumerable<City>>
    {
        public GetAllCities() : base(Signature.Create("getAllCities", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<City>> Parse(HttpResponseMessage responseMessage)
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

                  return new City
                  {
                      Id = array[0].ToObject<int>(),
                      Name = array[1].ToObject<string>(),
                  };
                });
            }
            throw new FilmWebException(FilmWebExceptionType.UnableToGetData);
        }
    }
}
