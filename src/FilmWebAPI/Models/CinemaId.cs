using System;

namespace FilmWebAPI.Models
{
    public class CinemaId
    {
        public CinemaId(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _value = value;
        }

        private readonly long _value;

        public static implicit operator long(CinemaId cinemaId) => cinemaId._value;

        public static implicit operator CinemaId(long id) => new CinemaId(id);
    }
}