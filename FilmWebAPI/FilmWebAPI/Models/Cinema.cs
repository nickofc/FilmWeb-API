namespace FilmWebAPI.Models
{
    public class Cinema
    {
        public int Id { get; internal set; }

        public string Name { get; internal set; }

        public double? Latitude { get; internal set; }

        public double? Longitude { get; internal set; }

        public int CityId { get; internal set; }

        public string Address { get; internal set; }

        public string Phone { get; internal set; }
    }
}