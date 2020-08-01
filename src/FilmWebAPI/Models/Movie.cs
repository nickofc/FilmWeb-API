using System;
using System.Collections.Generic;

namespace FilmWebAPI.Models
{
    public class Movie
    {
        public MovieId Id { get; internal set; }
        public Uri PhotoUrl { get; internal set; }
        public IReadOnlyCollection<string> Titles { get; internal set; } = new List<string>();
        public int? ProductionYear { get; internal set; }
        public string Caption { get; internal set; }

        public static Movie GetFromMovieSearchItem(MovieSearchItem item)
        {
            return new Movie
            {
                Id = item.GetId(),
                Titles = item.GetTitles(),
                ProductionYear = item.GetProductionYear(),
                Caption = item.GetCaption(),
                PhotoUrl = item.GetPhotoUrl()
            };
        }
    }
}