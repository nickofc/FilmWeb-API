namespace FilmWebAPI.Models
{
    public class Person
    {
        public long Id { get; internal set; }

        public string Name { get; internal set; }

        public string KnownAs { get; internal set; }
    }
}