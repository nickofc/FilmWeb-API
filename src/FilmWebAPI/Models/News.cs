using System;

namespace FilmWebAPI.Requests.Get
{
    public class News
    {
        public NewsId Id { get; internal set; }
        public string Title { get; internal set; }
        public string ShortBody { get; internal set; }
        public string FullBody { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public Uri Image { get; internal set; }

        /// <summary>
        /// Probably category
        /// </summary>
        public object UnknownField1 { get; internal set; }
        public object UnknownField2 { get; internal set; }
        public object UnknownField3 { get; internal set; }
    }
}