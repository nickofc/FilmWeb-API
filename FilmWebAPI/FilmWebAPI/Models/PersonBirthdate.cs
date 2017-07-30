using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI.Models
{
    public class PersonBirthdate
    {
        public DateTime Birthdate { get; set; }
        public DateTime Deathdate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public bool IsAlive => Deathdate <= Birthdate;
    }
}
