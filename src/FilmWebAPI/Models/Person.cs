namespace FilmWebAPI.Models
{
    public class Person
    {
        public long Id { get; internal set; }
        public string InFilm { get; internal set; }
        public string SubTitle { get; internal set; }
        public string Name { get; internal set; }
        public string ImageUrl { get; internal set; }
    }
}