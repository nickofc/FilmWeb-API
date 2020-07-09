namespace FilmWebAPI.Models
{
    public class Cinema
    {
        public CinemaId Id { get; internal set; }
        public string Name { get; internal set; }
        public Location Location { get; internal set; }
        public int CityId { get; internal set; }
        public string Address { get; internal set; }
        public string Phone { get; internal set; }
    }
}