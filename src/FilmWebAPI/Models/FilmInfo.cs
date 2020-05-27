using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Models
{
    public class FilmInfo
    {
        public string PolishTitle { get; set; }
        public string EnglishTitle { get; set; }
        public double Score { get; set; }
        public long Votes { get; set; }
        public string Categories { get; set; }
        public DateTime CreatedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
