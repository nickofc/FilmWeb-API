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
    public class GetBornTodayPersons : RequestBase<PersonBirthdate[]>
    {
        public GetBornTodayPersons() : base(Signature.Create("getBornTodayPersons", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<PersonBirthdate[]> Parse(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (content.StartsWith("ok"))
            {
                var jsonBody = content.Remove(0, 3);
                var json = JArray.Parse(Regex.Replace(jsonBody, "t(s?):(\\d+)$", string.Empty));


                return json.Skip(1).Select(token =>
                {
                    var array = token as JArray;
                    if (array == null) return null;

                    return new PersonBirthdate
                    {
                        Id = array[0].ToObject<int>(),
                        Name = array[1].ToObject<string>(),
                        Poster = array[2].ToObject<string>(),
                        Birthdate = array[3].ToObject<DateTime>(),
                        Deathdate = array[4].HasValues ? array[4].ToObject<DateTime>() : DateTime.MinValue,
                    };
                }).ToArray();
            }
            throw new FilmWebException(FilmWebExceptionType.UnableToGetData);
        }
    }
}
