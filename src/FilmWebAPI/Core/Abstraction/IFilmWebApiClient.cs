using FilmWebAPI.Core.Communication;
using System.Threading;
using System.Threading.Tasks;

namespace FilmWebAPI.Core.Abstraction
{
    public interface IFilmWebApiClient
    {
        Task<T> Dispatch<T>(RequestBase<T> instance, CancellationToken token = default);
    }
}