using System.Linq;
using FilmWebAPI.Models;
using FilmWebAPI.Requests.Get.SearchImpl;

namespace FilmWebAPI.Requests.Get
{
    internal class AdvancedLiveSearchParser
    {
        internal SearchSummary Parse(string content)
        {
            var rows = content.Split("\\a").ToArray();
            var row = rows.Select(x => x.Split("\\c")).ToArray();

            var parsed = row
                .Select(x => new SearchItemBase(ItemTypeMap.Instance[x[0].ToLower()], x))
                .ToArray();

            var person = parsed
                .Where(x => x.ItemType == ItemType.osoba)
                .Select(x => new PersonSearchItem(x.ItemType, x.Raw))
                .ToArray();

            var movies = parsed
                .Where(x => x.ItemType == ItemType.film)
                .Select(x => new MovieSearchItem(x.ItemType, x.Raw))
                .ToArray();

            var serials = parsed
                .Where(x => x.ItemType == ItemType.serial)
                .Select(x => new SerialSearchItem(x.ItemType, x.Raw))
                .ToArray();

            return new SearchSummary(person, movies, serials);
        }
    }
}