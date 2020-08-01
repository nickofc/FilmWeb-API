using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests
{
    public class GetFilmPersons : JsonRequestBase<IReadOnlyCollection<Person>, JArray>
    {
        public GetFilmPersons(long movieId, PersonType personType, int pageId)
            : base(Signature.Create("getFilmPersons", movieId, (int)personType, pageId * 50, (pageId + 1) * 50), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<Person>> Parse(JArray entity)
        {
            return entity.Select(token =>
            {
                if (!(token is JArray array))
                    return null;

                return new Person
                {
                    Id = array[0].ToObject<long>(),
                    InFilm = array[1].ToObject<string>(),
                    SubTitle = array[2].ToObject<string>(),
                    Name = array[3].ToObject<string>(),
                    PhotoUrl = Core.Common.Parse.Url(array[4].ToObject<string>()),
                };

            }).ToArray();
        }
    }
}