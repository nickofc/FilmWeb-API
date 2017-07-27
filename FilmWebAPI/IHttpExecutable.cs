using System.Net.Http;

namespace FilmWebAPI
{
    public interface IHttpExecutable
    {
        HttpRequestMessage GetRequestMessage();
    }
}