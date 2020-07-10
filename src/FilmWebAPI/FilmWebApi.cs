using FilmWebAPI.Core.Abstraction;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using FilmWebAPI.Requests.Get;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public class FilmWebApi
    {
        public const string ApiUrl = "https://ssl.filmweb.pl/api";

        protected FilmWebConfig Config { get; set; }
        protected IFilmWebApiClient ApiClient { get; set; }

        public FilmWebApi(FilmWebConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            ApiClient = new FilmWebApiClient(config);
        }

        public FilmWebApi() : this(FilmWebConfig.Default)
        {

        }

        public async Task<IReadOnlyCollection<Person>> GetFilmPersons(ulong movieId, PersonType personType, int page, CancellationToken token = default)
        {
            var getFilmPersons = new GetFilmPersons(movieId, personType, page);
            return await ApiClient.Dispatch(getFilmPersons, token).ConfigureAwait(false);
        }

        public async Task<SearchSummary> Search(string query, CancellationToken token = default)
        {
            var search = new Search(query);
            return await ApiClient.Dispatch(search, token).ConfigureAwait(false);
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

        public async Task<IReadOnlyCollection<NewsListItem>> GetNews(uint page, CancellationToken token = default)
        {
            var getNewsList = new GetNewsList(page);
            return await ApiClient.Dispatch(getNewsList, token).ConfigureAwait(false);
        }

        public async Task<News> GetNews(NewsId newsId, CancellationToken token = default)
        {
            var getNews = new GetNews(newsId);
            return await ApiClient.Dispatch(getNews, token).ConfigureAwait(false);
        }
    }
}