﻿using System;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests
{
    public class GetBornTodayPersons : JsonRequestBase<PersonBirthdate[], JArray>
    {
        public GetBornTodayPersons() : base(Signature.Create("getBornTodayPersons", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<PersonBirthdate[]> Parse(JArray entity)
        {
            return entity.Select(token =>
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