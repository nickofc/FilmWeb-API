using System.Collections.Generic;

namespace FilmWebAPI.Requests.Get
{
    public static class ItemTypeMap
    {
        public static Dictionary<string, ItemType> Instance = new Dictionary<string, ItemType>
        {
            { "f", ItemType.film },
            { "s", ItemType.serial },
            { "tv", ItemType.program },
            { "g", ItemType.gra },
            { "p", ItemType.osoba },
            { "a", ItemType.award },
            { "c", ItemType.cinema },
            { "t", ItemType.channel },
            { "r", ItemType.reklama },
            { "rn", ItemType.reklama2 },
            { "ml", ItemType.strona },
            { "ms", ItemType.materiał_sponsorowany },
            { "mp", ItemType.materiał_partnerski },
            { "msss", ItemType.sekcja_specjalna_materiał_sponsorowany },
            { "u", ItemType.znajomy }
        };
    }
}