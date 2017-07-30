using System;
using System.Collections.Generic;
using System.Text;

namespace FilmWebAPI.Models
{
    public class FilmType
    {
        public enum Type
        {
            Movie,
            Serial,
            Game, 
            Unknown,
        }
        public static int FILM = 0;
        public static int GAME = 2;
        public static int SERIAL = 1;

        public static Type GetDescription(int filmType)
        {
            switch (filmType)
            {
                case 0:
                    return Type.Movie;
                case 1:
                    return Type.Serial;
                case 2:
                    return Type.Game;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filmType));
            }
        }

        public static Type GetDescription(string filmType)
        {
            if (filmType.Equals("film"))
            {
                return Type.Movie;
            }
            if (filmType.Equals("serial"))
            {
                return Type.Serial;
            }
            if (filmType.Equals("videogame"))
            {
                return Type.Game;
            }
            return Type.Unknown;
        }
    }
}
