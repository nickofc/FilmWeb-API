using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI
{
    public interface IFilmWebApiClient
    {
        Task<T> Dispatch<T>(RequestBase<T> instance, CancellationToken token = default);
    }
}