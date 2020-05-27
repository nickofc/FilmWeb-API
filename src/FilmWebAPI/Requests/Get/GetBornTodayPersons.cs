using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetBornTodayPersons : JsonRequestBase<PersonBirthdate[], JArray>
    {
        public GetBornTodayPersons() : base(Signature.Create("getBornTodayPersons", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<PersonBirthdate[]> Parse(JArray entity)
        {
            return entity.Skip(1).Select(token =>
            {
                if (!(token is JArray array)) 
                    return null;

                return new PersonBirthdate
                {
                    Id = array[0].ToObject<int>(),
                    Name = array[1].ToObject<string>(),
                    Poster = array[2].ToObject<string>(),
                    Birthdate = array[3].ToObject<DateTime>(),
                    Deathdate = array[4].HasValues ? array[4].ToObject<DateTime>() : default
                };
            }).ToArray();
        }
    }
}