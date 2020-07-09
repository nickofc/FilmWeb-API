using System;

namespace FilmWebAPI.Models
{
    public class FilmInfo
    {
        public string PolishTitle { get; internal set; }
        public string EnglishTitle { get; internal set; }
        public double Score { get; internal set; }
        public long Votes { get; internal set; }
        public string Categories { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public TimeSpan Duration { get; internal set; }
        public string Image { get; internal set; }
        public string Country { get; internal set; }
        public string Description { get; internal set; }
    }
}
