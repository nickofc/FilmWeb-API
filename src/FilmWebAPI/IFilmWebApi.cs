using System;
using FilmWebAPI.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public interface IFilmWebApi
    {
        Task<LoginResult> Login(string username, string password, CancellationToken token = default);

        void Logout();

        Task<IReadOnlyCollection<Channel>> GetAllChannels(CancellationToken token = default);

        Task<IReadOnlyCollection<Cinema>> GetAllCinemas(CancellationToken token = default);

        Task<IReadOnlyCollection<City>> GetAllCities(CancellationToken token = default);

        Task<IReadOnlyCollection<PersonBirthdate>> GetBornTodayPersons(CancellationToken token = default);

        Task<IReadOnlyCollection<Person>> GetFilmPersons(ulong movieId, PersonType personType, int page, CancellationToken token = default);

        Task<ulong?> GetMovieId(string movieTitle, CancellationToken token = default);

        Task<string> GetFilmPolishTitle(ulong movieId, CancellationToken token = default);

        Task<string> GetFilmOriginalTitle(ulong movieId, CancellationToken token = default);

        Task<double> GetFilmAvgVote(ulong movieId, CancellationToken token = default);

        Task<IEnumerable<string>> GetFilmGenres(ulong movieId, CancellationToken token = default);

        Task<IEnumerable<string>> GetFilmProductionCountries(ulong movieId, CancellationToken token = default);

        Task<TimeSpan> GetFilmDuration(ulong movieId, CancellationToken token = default);

        Task<IEnumerable<KeyValuePair<string, DateTime>>> GetFilmPremieres(ulong movieId, CancellationToken token = default);

        Task<string> GetFilmDescription(ulong movieId, CancellationToken token = default);

        Task<string> GetFilmShortDescription(ulong movieId, CancellationToken token = default);

        Task<ulong> GetFilmVotesCount(ulong movieId, CancellationToken token = default);
    }
}