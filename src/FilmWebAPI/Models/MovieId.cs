using System;

namespace FilmWebAPI.Models
{
    public class MovieId
    {
        public MovieId(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _value = value;
        }

        private readonly long _value;

        public static implicit operator long(MovieId movieId) => movieId._value;

        public static implicit operator MovieId(long id) => new MovieId(id);
    }
}