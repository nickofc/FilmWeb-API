using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Core.Abstraction
{
    public interface IRequest<T>
    {
        Task<T> Parse(HttpResponseMessage responseMessage);
    }
}