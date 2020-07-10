using System;

namespace FilmWebAPI.Requests.Get
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