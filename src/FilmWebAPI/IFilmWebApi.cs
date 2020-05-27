using FilmWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public interface IFilmWebApi
    {
        Task<IReadOnlyCollection<Channel>> GetAllChannels(CancellationToken token = default);

        Task<IReadOnlyCollection<City>> GetAllCities(CancellationToken token = default);

        Task<IReadOnlyCollection<PersonBirthdate>> GetBornTodayPersons(CancellationToken token = default);

        Task<IReadOnlyCollection<Person>> GetFilmPersons(ulong movieId, PersonType personType, int page, CancellationToken token = default);

        Task<ulong?> GetMovieId(string movieTitle, CancellationToken token = default);

        Task<FilmInfo> GetFilmInfo(ulong movieId, CancellationToken token = default);

        Task<string> GetFilmDescription(ulong movieId, CancellationToken token = default);
    }
}