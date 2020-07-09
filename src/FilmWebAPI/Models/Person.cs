using System;
using FilmWebAPI.Requests.Get;

namespace FilmWebAPI.Models
{
    public class Person
    {
        public PersonId Id { get; internal set; }
        public string InFilm { get; internal set; }
        public string SubTitle { get; internal set; }
        public string Name { get; internal set; }
        public Uri PhotoUrl { get; internal set; }

        public static Person GetFromPersonSearchItem(PersonSearchItem item)
        {
            return new Person
            {
                Id = item.GetId(),
                PhotoUrl = item.GetPhotoUrl(),
            };
        }
    }
}