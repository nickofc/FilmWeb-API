using System;

namespace FilmWebAPI.Models
{
    public class ChannelId
    {
        public ChannelId(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _value = value;
        }

        private readonly long _value;

        public static implicit operator long(ChannelId channelId) => channelId._value;

        public static implicit operator ChannelId(long id) => new ChannelId(id);
    }
}