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

        Task<IReadOnlyCollection<Person>> GetFilmPersons(long movieId, PersonType personType, int page, CancellationToken token = default);
    }
}