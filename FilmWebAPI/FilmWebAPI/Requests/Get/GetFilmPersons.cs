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
    public class GetFilmPersons : RequestBase<IEnumerable<Person>>
    {
        public GetFilmPersons(long movieId, int type, int pageId) 
            : base(Signature.Create("getFilmPersons", movieId, type, pageId * 50, (pageId + 1) * 50), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IEnumerable<Person>> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            return json.Select(token =>
            {
                if (!(token is JArray array))
                    return null;

                return new Person(personId: array[0].ToObject<ulong>(),
                                  personName: array[3].ToObject<string>(),
                                  knownAs: array[1].ToObject<string>());

            });
        }
    }
}
