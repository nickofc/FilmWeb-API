using System;

namespace FilmWebAPI.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int DayStartHour { get; set; }

        public Uri GetImageUri()
        {
            return new Uri($"http://1.fwcdn.pl/channels/{ImagePath}");
        }
    }
}