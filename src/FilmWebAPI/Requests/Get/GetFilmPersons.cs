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
    public class GetFilmPersons : RequestBase<IReadOnlyCollection<Person>>
    {
        public GetFilmPersons(long movieId, PersonType personType, int pageId)
            : base(Signature.Create("getFilmPersons", movieId, (int)personType, pageId * 50, (pageId + 1) * 50), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<Person>> Parse(HttpResponseMessage responseMessage)
        {
            var jsonBody = await base.GetJsonBody(responseMessage);
            var json = JsonConvert.DeserializeObject<JArray>(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));

            return json.Select(token =>
            {
                if (!(token is JArray array))
                    return null;

                return new Person()
                {
                    Id = array[0].ToObject<long>(),
                    Name = array[3].ToObject<string>(),
                    KnownAs = array[1].ToObject<string>()
                };

            }).ToArray();
        }
    }
}