using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public interface IHttpExecute
    {
        Task<HttpResponseMessage> Execute(HttpRequestMessage message, CancellationToken token = default);
    }
}