using FilmWebAPI.Core.Abstraction;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using FilmWebAPI.Requests.Get;
using FilmWebAPI.Requests.Post;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public class FilmWebApi : IFilmWebApi
    {
        public const string API_URL = "https://ssl.filmweb.pl/api";

        protected FilmWebConfig Config { get; set; }

        protected IFilmWebApiClient ApiClient { get; set; }

        public FilmWebApi(FilmWebConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            ApiClient = new FilmWebApiClient(config);
        }

        public FilmWebApi() : this(FilmWebConfig.Default())
        {

        }

        // todo: fix login
        /// <summary>
        /// Pozwala zalogować się do serwisu
        /// </summary>
        /// <param name="username">Nazwa użytkownika lub adres e-mail</param>
        /// <param name="password">Hasło</param>
        /// <param name="token">Token do przerwania zadania</param>
        /// <returns>Zwraca informacje (<see cref="LoginResult"/>) o użytkowniku i stanie operacji</returns>
        public async Task<LoginResult> Login(string username, string password, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Nazwa użytkownika nie może być pusta.", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Hasło nie może być puste.", nameof(password));
            }

            var login = new Login(username, password);
            return await ApiClient.Dispatch(login, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Powoduje wylogowanie się z sesji
        /// </summary>
        public void Logout()
        {
            ApiClient = new FilmWebApiClient(Config);
        }

        public async Task<IReadOnlyCollection<Person>> GetFilmPersons(ulong movieId, PersonType personType, int page, CancellationToken token = default)
        {
            var getFilmPersons = new GetFilmPersons(movieId, personType, page);
            return await ApiClient.Dispatch(getFilmPersons, token).ConfigureAwait(false);
        }

        public async Task<ulong?> GetMovieId(string movieTitle, CancellationToken token = default)
        {
            var search = new Search(movieTitle);
            return await ApiClient.Dispatch(search, token);
        }

        public async Task<IReadOnlyCollection<PersonBirthdate>> GetBornTodayPersons(CancellationToken token = default)
        {
            var getBornTodayPersons = new GetBornTodayPersons();
            return await ApiClient.Dispatch(getBornTodayPersons, token).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<City>> GetAllCities(CancellationToken token = default)
        {
            var getAllCities = new GetAllCities();
            return await ApiClient.Dispatch(getAllCities, token).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Channel>> GetAllChannels(CancellationToken token = default)
        {
            var getAllChannels = new GetAllChannels();
            return await ApiClient.Dispatch(getAllChannels, token).ConfigureAwait(false);
        }

        public async Task<FilmInfo> GetFilmInfo(ulong movieId, CancellationToken token = default)
        {
            var getDuration = new GetFilmInfoFull(movieId);
            return await ApiClient.Dispatch(getDuration, token).ConfigureAwait(false);
        }

        public async Task<string> GetFilmDescription(ulong movieId, CancellationToken token = default)
        {
            var getDescription = new GetFilmDescription(movieId);
            return await ApiClient.Dispatch(getDescription, token).ConfigureAwait(false);
        }
    }
}