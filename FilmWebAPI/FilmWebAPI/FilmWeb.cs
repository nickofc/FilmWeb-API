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
                    {"User-Agent", "FilmWebAPI"},
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
        /// <param name="token">Token do przerwania zadania</param>
        /// <exception cref="FilmWebException">Wrzuca wyjątek jeśli dane do logowania są błędne.</exception>
        /// <returns>Zwraca informacje (<see cref="User"/>) o użytkowniku.</returns>
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


        public async Task<IEnumerable<Cinema>> GetFilmVideos(long movieId, int page, CancellationToken token = default(CancellationToken))
        {
            var recommendation = new GetFilmVideos(movieId, page);
            using (var message = await _httpExecute.Execute(recommendation.GetRequestMessage(), token))
            {
                return await recommendation.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmUserRecommendation(long movieId, CancellationToken token = default(CancellationToken))
        {
            var recommendation = new GetFilmUserRecommendation(movieId);
            using (var message = await _httpExecute.Execute(recommendation.GetRequestMessage(), token))
            {
                return await recommendation.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmUserConnectionsCount(long movieId, CancellationToken token = default(CancellationToken))
        {
            var connectionsCount = new GetFilmUserConnectionsCount(movieId);
            using (var message = await _httpExecute.Execute(connectionsCount.GetRequestMessage(), token))
            {
                return await connectionsCount.Parse(message).ConfigureAwait(false);
            }
        }


        public async Task<IEnumerable<Cinema>> GetFilmsNearestBroadcasts(long movieId, int page, CancellationToken token = default(CancellationToken))
        {
            var broadcasts = new GetFilmsNearestBroadcasts(movieId, page);
            using (var message = await _httpExecute.Execute(broadcasts.GetRequestMessage(), token))
            {
                return await broadcasts.Parse(message).ConfigureAwait(false);
            }
        }


        public async Task<IEnumerable<Cinema>> GetFilmsInfoShort(long movieId, CancellationToken token = default(CancellationToken))
        {
            var infoShort = new GetFilmsInfoShort(movieId);
            using (var message = await _httpExecute.Execute(infoShort.GetRequestMessage(), token))
            {
                return await infoShort.Parse(message).ConfigureAwait(false);
            }
        }


        public async Task<IEnumerable<Cinema>> GetFilmReview(long movieId, CancellationToken token = default(CancellationToken))
        {
            var review = new GetFilmReview(movieId);
            using (var message = await _httpExecute.Execute(review.GetRequestMessage(), token))
            {
                return await review.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmProfessionCounts(long movieId, CancellationToken token = default(CancellationToken))
        {
            var filmProfessionCounts = new GetFilmProfessionCounts(movieId);
            using (var message = await _httpExecute.Execute(filmProfessionCounts.GetRequestMessage(), token))
            {
                return await filmProfessionCounts.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmPersonsLead(long movieId, int size, CancellationToken token = default(CancellationToken))
        {
            var persons = new GetFilmPersonsLead(movieId, size);
            using (var message = await _httpExecute.Execute(persons.GetRequestMessage(), token))
            {
                return await persons.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmPersons(long movieId, int type, int page, CancellationToken token = default(CancellationToken))
        {
            var persons = new GetFilmPersons(movieId, type, page);
            using (var message = await _httpExecute.Execute(persons.GetRequestMessage(), token))
            {
                return await persons.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmInfoFull(long movieId, CancellationToken token = default(CancellationToken))
        {
            var filmInfoFull = new GetFilmInfoFull(movieId);
            using (var message = await _httpExecute.Execute(filmInfoFull.GetRequestMessage(), token))
            {
                return await filmInfoFull.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmImages(long movieId, int page, CancellationToken token = default(CancellationToken))
        {
            var filmImages = new GetFilmImages(movieId, page);
            using (var message = await _httpExecute.Execute(filmImages.GetRequestMessage(), token))
            {
                return await filmImages.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmDescription(long movieId, CancellationToken token = default(CancellationToken))
        {
            var description = new GetFilmDescription(movieId);
            using (var message = await _httpExecute.Execute(description.GetRequestMessage(), token))
            {
                return await description.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetFilmComments(long movieId, int page, CancellationToken token = default(CancellationToken))
        {
            var friendsInfo = new GetFilmComments(movieId, page);
            using (var message = await _httpExecute.Execute(friendsInfo.GetRequestMessage(), token))
            {
                return await friendsInfo.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCurrentUserFriendsInfo(CancellationToken token = default(CancellationToken))
        {
            var friendsInfo = new GetCurrentUserFriendsInfo();
            using (var message = await _httpExecute.Execute(friendsInfo.GetRequestMessage(), token))
            {
                return await friendsInfo.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetConfiguration(string name, CancellationToken token = default(CancellationToken))
        {
            var configuration = new GetConfiguration(name);
            using (var message = await _httpExecute.Execute(configuration.GetRequestMessage(), token))
            {
                return await configuration.Parse(message).ConfigureAwait(false);
            }
        }


        public async Task<IEnumerable<Cinema>> GetCommingSoon(CancellationToken token = default(CancellationToken))
        {
            var commingSoon = new GetCommingSoon();
            using (var message = await _httpExecute.Execute(commingSoon.GetRequestMessage(), token))
            {
                return await commingSoon.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCityRepertoireDays(long cityId, CancellationToken token = default(CancellationToken))
        {
            var repertoireDays = new GetCityRepertoireDays(cityId);
            using (var message = await _httpExecute.Execute(repertoireDays.GetRequestMessage(), token))
            {
                return await repertoireDays.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCinemaRepertoireDays(Cinema cinema, CancellationToken token = default(CancellationToken))
        {
            return await GetCinemaRepertoireDays(cinema.Id, token);
        }
        public async Task<IEnumerable<Cinema>> GetCinemaRepertoireDays(long cinemaId, CancellationToken token = default(CancellationToken))
        {
            var repertoireDays = new GetCinemaRepertoireDays(cinemaId);
            using (var message = await _httpExecute.Execute(repertoireDays.GetRequestMessage(), token))
            {
                return await repertoireDays.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<PersonBirthdate[]> GetBornTodayPersons(CancellationToken token = default(CancellationToken))
        {
            var persons = new GetBornTodayPersons();
            using (var message = await _httpExecute.Execute(persons.GetRequestMessage(), token))
            {
                return await persons.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<City>> GetAllCities(CancellationToken token = default(CancellationToken))
        {
            var cities = new GetAllCities();
            using (var message = await _httpExecute.Execute(cities.GetRequestMessage(), token))
            {
                return await cities.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Cinema>> GetAllCinemas(CancellationToken token = default(CancellationToken))
        {
            var cinemas = new GetAllCinemas();
            using (var message = await _httpExecute.Execute(cinemas.GetRequestMessage(), token))
            {
                return await cinemas.Parse(message).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Channel>> GetAllChannels(CancellationToken token = default(CancellationToken))
        {
            var channels = new GetAllChannels();
            using (var message = await _httpExecute.Execute(channels.GetRequestMessage(), token))
            {
                return await channels.Parse(message).ConfigureAwait(false);
            }
        }

        //public async Task<IEnumerable<Cinema>> GenerateCaptcha(CancellationToken token = default(CancellationToken))
        //{
        //    var captcha = new GenerateCaptcha();
        //    using (var message = await _httpExecute.Execute(captcha.GetRequestMessage(), token))
        //    {
        //        return await captcha.Parse(message).ConfigureAwait(false);
        //    }
        //}


        #endregion

        /// <summary>
        /// Powoduje wylogowanie się z sesji
        /// </summary>
        public void CleanupCookies()
        {
            _cookie = new CookieContainer();
        }
    }
}