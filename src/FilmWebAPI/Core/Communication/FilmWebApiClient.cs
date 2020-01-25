using System;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI.Core.Communication
{
    public class FilmWebApiClient : IFilmWebApiClient
    {
        private readonly HttpExecute _httpExecute;

        public FilmWebApiClient(HttpExecute httpExecute)
        {
            _httpExecute = httpExecute ?? throw new ArgumentNullException(nameof(httpExecute));
        }

        public async Task<T> Dispatch<T>(RequestBase<T> instance, CancellationToken token = default)
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            using (var message = await _httpExecute.Execute(instance.GetRequestMessage(), token).ConfigureAwait(false))
            {
                return await instance.Parse(message).ConfigureAwait(false);
            }
        }
    }
}