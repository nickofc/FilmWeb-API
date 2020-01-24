using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public interface IRequest<T>
    {
        Task<T> Parse(HttpResponseMessage responseMessage);
    }
}