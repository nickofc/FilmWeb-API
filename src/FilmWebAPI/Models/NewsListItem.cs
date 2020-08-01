using System;

namespace FilmWebAPI.Models
{
    public class NewsListItem
    {
        public NewsId Id { get; internal set; }
        public string Title { get; internal set; }
        public string ShortBody { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public Uri Image { get; internal set; }
        public string BackingFieldType { get; internal set; }
    }
}