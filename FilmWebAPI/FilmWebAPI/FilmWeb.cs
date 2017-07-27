using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FilmWebAPI.Models;
using FilmWebAPI.Requests.Get;
using FilmWebAPI.Requests.Post;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI
{
    public class FilmWeb
    {
        #region Constant

        public const string API_URL = "https://ssl.filmweb.pl/api";
        public const string API_KEY = "qjcGhW2JnvGT9dfCt3uT_jozR3s";

        #endregion

        private CookieContainer _cookie;
        private readonly HttpExecute _httpExecute;

        //TODO: Max age regex pattern t(s?):(\\d+)$

        public FilmWeb(CookieContainer cookies = default(CookieContainer), int timeout = 10)
        {
            _cookie = cookies ?? new CookieContainer();
            _httpExecute = new HttpExecute(new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = _cookie,
                UseCookies = true,
            }, true)
            {
                BaseAddress = new Uri(API_URL),
                DefaultRequestHeaders =
                {
                    {"User-Agent", "SunnyAPI"},
                    {"Accept-Encoding", "gzip, deflate"},
                },
                Timeout = TimeSpan.FromSeconds(timeout),
            });
        }

        #region Post Methods

        /// <summary>
        /// Pozwala zalogować się do serwisu.
        /// </summary>
        /// <param name="username">Nazwa użytkownika lub adres e-mail.</param>
        /// <param name="password">Hasło.</param>
        /// <exception cref="FilmWebException">Wrzuca wyjątek jeśli dane do logowania są błędne.</exception>
        /// <returns>Zwraca informacje o użytkowniku.</returns>
        public async Task<User> Login(string username, string password, CancellationToken token = default(CancellationToken))
        {
            var login = new Login(username, password);
            using (var message = await _httpExecute.Execute(login.GetRequestMessage(), token))
            {
                return await login.Parse(message).ConfigureAwait(false);
            }
        }

        #endregion


        #region Get Methods

        /// <summary>
        /// Pobiera liste kin
        /// </summary>
        /// <returns><</returns>
        public async Task<IEnumerable<Cinema>> GetAllCinemas(CancellationToken token = default(CancellationToken))
        {
            var cinemas = new GetAllCinemas();
            using (var message = await _httpExecute.Execute(cinemas.GetRequestMessage(), token))
            {
                return await cinemas.Parse(message).ConfigureAwait(false);
            }
        }

        #endregion

        public void CleanupCookies()
        {
            _cookie = new CookieContainer();
        }
    }
}