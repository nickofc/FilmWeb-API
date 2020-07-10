using System;
using System.Collections.Generic;
using System.Text;
using FilmWebAPI.Requests.Get;
using FilmWebAPI.Requests.Get.SearchImpl;

namespace FilmWebAPI.Models
{
    public class SearchSummary
    {
        public IReadOnlyCollection<PersonSearchItem> Person { get; }
        public IReadOnlyCollection<MovieSearchItem> Movies { get; }
        public IReadOnlyCollection<SerialSearchItem> Serials { get; }
        public SearchSummary(IReadOnlyCollection<PersonSearchItem> person, 
            IReadOnlyCollection<MovieSearchItem> movies, IReadOnlyCollection<SerialSearchItem> serials)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
            Movies = movies ?? throw new ArgumentNullException(nameof(movies));
            Serials = serials ?? throw new ArgumentNullException(nameof(serials));
        }
    }
}
