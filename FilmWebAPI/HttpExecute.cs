using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmWebAPI
{
    public class HttpExecute : IDisposable
    {
        private readonly HttpClient _httpClient;

        public HttpExecute(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Execute(HttpRequestMessage message, CancellationToken token = default(CancellationToken))
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            return await _httpClient.SendAsync(message, HttpCompletionOption.ResponseContentRead, token).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}