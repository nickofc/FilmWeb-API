using System;

namespace FilmWebAPI.Models
{
    public class PersonId
    {
        public PersonId(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _value = value;
        }

        private readonly long _value;

        public static implicit operator long(PersonId personId) => personId._value;

        public static implicit operator PersonId(long id) => new PersonId(id);
    }
}