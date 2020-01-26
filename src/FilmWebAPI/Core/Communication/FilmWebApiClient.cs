using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI.Core.Communication
{
    public class FilmWebApiClient : IFilmWebApiClient
    {
        private readonly HttpExecute _httpExecute;

        public FilmWebApiClient(FilmWebConfig filmWebConfig)
        {
            _httpExecute = new HttpExecute(new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = new CookieContainer(),
                UseCookies = true,
            }, true)
            {
                BaseAddress = new Uri(FilmWeb.API_URL),
                DefaultRequestHeaders =
                {
                    {"User-Agent", "FilmWebAPI"},
                    {"Accept-Encoding", "gzip, deflate"},
                },
                Timeout = filmWebConfig.Timeout,
            });
        }

        public async Task<T> Dispatch<T>(RequestBase<T> instance, CancellationToken token = default)
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            using (var request = instance.GetRequestMessage())
            using (var message = await _httpExecute.Execute(request, token).ConfigureAwait(false))
            {
                return await instance.Parse(message).ConfigureAwait(false);
            }
        }
    }
}