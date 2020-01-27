using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using FilmWebAPI.Requests.Get;
using FilmWebAPI.Requests.Post;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public class FilmWeb : IFilmWebApi
    {
        public const string API_URL = "https://ssl.filmweb.pl/api";

        protected FilmWebConfig Config { get; set; }

        protected FilmWebApiClient ApiClient { get; set; }

        public FilmWeb(FilmWebConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            ApiClient = new FilmWebApiClient(config);
        }

        public FilmWeb() : this(FilmWebConfig.Default())
        {

        }

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
            return await ApiClient.Dispatch(login, token);
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
            return await ApiClient.Dispatch(getFilmPersons, token);
        }

        public async Task<ulong?> GetMovieId(string movieTitle, CancellationToken token = default)
        {
            var search = new Search(movieTitle);
            return await ApiClient.Dispatch(search, token);
        }

        public async Task<IReadOnlyCollection<PersonBirthdate>> GetBornTodayPersons(CancellationToken token = default)
        {
            var getBornTodayPersons = new GetBornTodayPersons();
            return await ApiClient.Dispatch(getBornTodayPersons, token);
        }

        public async Task<IReadOnlyCollection<City>> GetAllCities(CancellationToken token = default)
        {
            var getAllCities = new GetAllCities();
            return await ApiClient.Dispatch(getAllCities, token);
        }

        public async Task<IReadOnlyCollection<Cinema>> GetAllCinemas(CancellationToken token = default)
        {
            var getAllCinemas = new GetAllCinemas();
            return await ApiClient.Dispatch(getAllCinemas, token);
        }

        public async Task<IReadOnlyCollection<Channel>> GetAllChannels(CancellationToken token = default)
        {
            var getAllChannels = new GetAllChannels();
            return await ApiClient.Dispatch(getAllChannels, token);
        }

        public async Task<string> GetFilmPolishTitle(ulong movieId, CancellationToken token = default)
        {
            var getPolishTitle = new GetFilmPolishTitle(movieId);
            return await ApiClient.Dispatch(getPolishTitle, token);
        }

        public async Task<string> GetFilmOriginalTitle(ulong movieId, CancellationToken token = default)
        {
            var getOriginalTitle = new GetFilmOriginalTitle(movieId);
            return await ApiClient.Dispatch(getOriginalTitle, token);
        }

        public async Task<double> GetFilmAvgVote(ulong movieId, CancellationToken token = default)
        {
            var getAvgVote = new GetFilmVotesAvg(movieId);
            return await ApiClient.Dispatch(getAvgVote, token);
        }

        public async Task<IEnumerable<string>> GetFilmGenres(ulong movieId, CancellationToken token = default)
        {
            var getGenres = new GetFilmGenres(movieId);
            return await ApiClient.Dispatch(getGenres, token);
        }

        public async Task<IEnumerable<string>> GetFilmProductionCountries(ulong movieId, CancellationToken token = default)
        {
            var getCountries = new GetFilmProductionCountries(movieId);
            return await ApiClient.Dispatch(getCountries, token);
        }

        public async Task<TimeSpan> GetFilmDuration(ulong movieId, CancellationToken token = default)
        {
            var getDuration = new GetFilmDuration(movieId);
            return await ApiClient.Dispatch(getDuration, token);
        }

        public async Task<IEnumerable<KeyValuePair<string, DateTime>>> GetFilmPremieres(ulong movieId, CancellationToken token = default)
        {
            var getPremieres = new GetFilmPremieres(movieId);
            return await ApiClient.Dispatch(getPremieres, token);
        }

        public async Task<string> GetFilmDescription(ulong movieId, CancellationToken token = default)
        {
            var getDescription = new GetFilmDescription(movieId);
            return await ApiClient.Dispatch(getDescription, token);
        }

        public async Task<string> GetFilmShortDescription(ulong movieId, CancellationToken token = default)
        {
            var getShortDescription = new GetFilmShortDescription(movieId);
            return await ApiClient.Dispatch(getShortDescription, token);
        }
    }
}