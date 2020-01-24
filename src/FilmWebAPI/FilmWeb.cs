using FilmWebAPI.Models;
using FilmWebAPI.Requests.Get;
using FilmWebAPI.Requests.Post;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public class FilmWeb : IFilmWebApi
    {
        #region Constant

        public const string API_URL = "https://ssl.filmweb.pl/api";
        public const string API_KEY = "qjcGhW2JnvGT9dfCt3uT_jozR3s";

        #endregion Constant

        private CookieContainer _cookie;

        protected HttpExecute HttpExecute { get; set; }

        protected FilmWebApiClient ApiClient { get; set; }

        //TODO: Max age regex pattern t(s?):(\\d+)$

        public FilmWeb(CookieContainer cookies = default, int timeoutInSeconds = 10)
        {
            _cookie = cookies ?? new CookieContainer();
            HttpExecute = new HttpExecute(new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = _cookie,
                UseCookies = true,
            }, true)
            {
                BaseAddress = new Uri(API_URL),
                DefaultRequestHeaders =
                {
                    {"User-Agent", "FilmWebAPI"},
                    {"Accept-Encoding", "gzip, deflate"},
                },
                Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
            });
            ApiClient = new FilmWebApiClient(HttpExecute);
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
            var login = new Login(username, password);
            return await ApiClient.Dispatch(login, token);
        }

        public async Task<IReadOnlyCollection<Person>> GetFilmPersons(long movieId, PersonType personType, int page, CancellationToken token = default)
        {
            var getFilmPersons = new GetFilmPersons(movieId, personType, page);
            return await ApiClient.Dispatch(getFilmPersons, token);
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

        /// <summary>
        /// Powoduje wylogowanie się z sesji
        /// </summary>
        public void Logout()
        {
            _cookie = new CookieContainer();
        }
    }
}