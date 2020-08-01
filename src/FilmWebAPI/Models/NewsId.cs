using System;

namespace FilmWebAPI.Models
{
    public class NewsId
    {
        public NewsId(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _value = value;
        }

        private readonly long _value;

        public static implicit operator long(NewsId newsId) => newsId._value;

        public static implicit operator NewsId(long id) => new NewsId(id);
    }
}