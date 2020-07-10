using FilmWebAPI.Core.Abstraction;
using FilmWebAPI.Core.Exception;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI.Core.Communication
{
    public class FilmWebApiClient : IFilmWebApiClient
    {
        private readonly IHttpExecute _httpExecute;

        public FilmWebApiClient() : this(FilmWebConfig.Default)
        {

        }

        public FilmWebApiClient(FilmWebConfig filmWebConfig)
        {
            if (filmWebConfig == null)
            {
                throw new ArgumentNullException(nameof(filmWebConfig));
            }

            _httpExecute = new HttpExecute(new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = new CookieContainer(),
                UseCookies = true
            }, true)
            {
                BaseAddress = new Uri(FilmWebApi.ApiUrl),
                DefaultRequestHeaders =
                {
                    {"User-Agent", "FilmWebAPI"},
                    {"Accept-Encoding", "gzip, deflate"}
                },
                Timeout = filmWebConfig.Timeout
            });
        }

        public async Task<T> Dispatch<T>(RequestBase<T> instance,
            CancellationToken token = default)
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return await InnerDispatch(instance, token);
        }

        private async Task<T> InnerDispatch<T>(RequestBase<T> instance,
            CancellationToken token)
        {
            try
            {
                using (var request = instance.GetRequestMessage())
                using (var message = await _httpExecute.Execute(request, token)
                    .ConfigureAwait(false))
                {
                    return await ParseAsync(instance, message)
                        .ConfigureAwait(false);
                }
            }
            catch (System.Exception exception)
            {
                throw new FilmWebException("There was an exception during the dispatch.", exception);
            }
        }

        private static async Task<T> ParseAsync<T>(IRequest<T> instance,
            HttpResponseMessage message)
        {
            try
            {
                return await instance.Parse(message)
                    .ConfigureAwait(false);
            }
            catch (System.Exception exception)
            {
                throw new FilmWebParseException("There was an exception during the parse.", exception);
            }
        }
    }
}