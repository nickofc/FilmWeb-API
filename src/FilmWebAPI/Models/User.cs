using System;

namespace FilmWebAPI.Models
{
    public class User
    {
        public int Id { get; internal set; }

        public string Nick { get; internal set; }

        public string Name { get; internal set; }

        public Sex Sex { get; internal set; }

        public DateTime Birthday { get; internal set; }
    }

    public enum Sex
    {
        Male,
        Female,
    }
}