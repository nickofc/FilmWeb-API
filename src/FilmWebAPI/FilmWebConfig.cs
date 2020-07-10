using System;

namespace FilmWebAPI
{
    public class FilmWebConfig
    {
        private TimeSpan _timeout;

        public TimeSpan Timeout
        {
            get => _timeout;
            set
            {
                if (value.TotalMilliseconds < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _timeout = value;
            }
        }

        public static FilmWebConfig Default
        {
            get
            {
                return new FilmWebConfig
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };
            }
        }
    }
}