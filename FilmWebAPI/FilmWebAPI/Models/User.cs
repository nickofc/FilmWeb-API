using System;

namespace FilmWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as User;
            return other != null && Id == other.Id && string.Equals(Nick, other.Nick) && string.Equals(Name, other.Name) && Sex == other.Sex && Birthday.Equals(other.Birthday);
        }
    }

    public enum Sex
    {
        Male,
        Female,
    }
}