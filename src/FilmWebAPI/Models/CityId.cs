using System;

namespace FilmWebAPI.Models
{
    public class CityId
    {
        public CityId(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _value = value;
        }

        private readonly long _value;

        public static implicit operator long(CityId cityId) => cityId._value;

        public static implicit operator CityId(long id) => new CityId(id);
    }
}