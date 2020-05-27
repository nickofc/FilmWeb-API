using System.Threading;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Core.Abstraction
{
    public interface IFilmWebApiClient
    {
        Task<T> Dispatch<T>(RequestBase<T> instance, CancellationToken token = default);
    }
}