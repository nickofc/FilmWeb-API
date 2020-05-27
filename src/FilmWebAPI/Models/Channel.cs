using System;

namespace FilmWebAPI.Models
{
    public class Channel
    {
        public int Id { get; internal set; }

        public string Name { get; internal set; }

        public string ImagePath { get; internal set; }

        public int DayStartHour { get; internal set; }

        public Uri GetImageUri()
        {
            return new Uri("http://1.fwcdn.pl/channels" + ImagePath);
        }
    }
}