using System;

namespace FilmWebAPI
{
    public class FilmWebConfig
    {
        public TimeSpan Timeout { get; set; }

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