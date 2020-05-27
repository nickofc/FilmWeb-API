using System;

namespace FilmWebAPI.Models
{
    public class PersonBirthdate
    {
        public int Id { get; internal set; }

        public DateTime Birthdate { get; internal set; }

        public DateTime? Deathdate { get; internal set; }

        public string Name { internal get; set; }

        public string Poster { get; internal set; }

        public bool IsAlive => Deathdate <= Birthdate;


        public Uri GetPosterUrl()
        {
            return new Uri("https://fwcdn.pl/ppo" + Poster);
        }
    }
}