using FilmWebAPI.Core.Abstraction;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Requests;
using FilmWebAPI.Requests.Get.Working.ToFix;

namespace FilmWebAPI
{
    public class FilmWebApi
    {
        public FilmWebApi() : this(FilmWebConfig.Default) { }
        
        public FilmWebApi(FilmWebConfig filmWebConfig)
        {
            FilmWebConfig = filmWebConfig ?? throw new ArgumentNullException(nameof(filmWebConfig));
            FilmWebApiClient = new FilmWebApiClient(filmWebConfig);
        }

        protected FilmWebConfig FilmWebConfig { get; set; }
        protected IFilmWebApiClient FilmWebApiClient { get; set; }

        public async Task<IReadOnlyCollection<Person>> GetFilmPersons(Movie movie, PersonType personType, int page,
            CancellationToken token = default)
        {
            return await GetFilmPersons(movie.Id, personType, page, token).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Person>> GetFilmPersons(MovieId movieId, PersonType personType, int page, CancellationToken token = default)
        {
            var getFilmPersons = new GetFilmPersons(movieId, personType, page);
            return await FilmWebApiClient.Dispatch(getFilmPersons, token).ConfigureAwait(false);
        }

        public async Task<SearchSummary> Search(string query, CancellationToken token = default)
        {
            var search = new Search(query);
            return await FilmWebApiClient.Dispatch(search, token).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<PersonBirthdate>> GetBornTodayPersons(CancellationToken token = default)
        {
            var getBornTodayPersons = new GetBornTodayPersons();
            return await FilmWebApiClient.Dispatch(getBornTodayPersons, token).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<City>> GetAllCities(CancellationToken token = default)
        {
            var getAllCities = new GetAllCities();
            return await FilmWebApiClient.Dispatch(getAllCities, token).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Channel>> GetAllChannels(CancellationToken token = default)
        {
            var getAllChannels = new GetAllChannels();
            return await FilmWebApiClient.Dispatch(getAllChannels, token).ConfigureAwait(false);
        }

        public async Task<FilmInfo> GetFilmInfo(MovieId movieId, CancellationToken token = default)
        {
            var getDuration = new GetFilmInfoFull(movieId);
            return await FilmWebApiClient.Dispatch(getDuration, token).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<NewsListItem>> GetNewsList(uint page, CancellationToken token = default)
        {
            var getNewsList = new GetNewsList(page);
            return await FilmWebApiClient.Dispatch(getNewsList, token).ConfigureAwait(false);
        }

        public async Task<News> GetNewsDetails(NewsListItem newsListItem, CancellationToken token = default)
        {
            return await GetNewsDetails(newsListItem.Id, token).ConfigureAwait(false);
        }

        public async Task<News> GetNewsDetails(NewsId newsId, CancellationToken token = default)
        {
            var getNews = new GetNews(newsId);
            return await FilmWebApiClient.Dispatch(getNews, token).ConfigureAwait(false);
        }
    }
}