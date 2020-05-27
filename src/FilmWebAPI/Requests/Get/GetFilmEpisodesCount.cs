using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmEpisodesCount : JsonRequestBase<int, JArray>
    {
        public GetFilmEpisodesCount(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<int> Parse(JArray entity)
        {
            const int EPISODES_COUNT_INDEX = 17;

            var parsed = int.TryParse(entity[EPISODES_COUNT_INDEX].ToString(), out var episodesCount);
            return parsed ? episodesCount : default;
        }
    }
}
