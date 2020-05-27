using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    /* todo check size */
    public class GetFilmPersonsLead : JsonRequestBase<IReadOnlyCollection<Person>, JArray>
    {
        public GetFilmPersonsLead(long movieId, int size) : base(Signature.Create("getFilmPersonsLead", movieId, size), FilmWebHttpMethod.Get)
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
                    ImageUrl = array[4].ToObject<string>()
                };

            }).ToArray();
        }
    }
}