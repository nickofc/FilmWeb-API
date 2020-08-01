using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests
{
    /* todo sprawdzic response */
    public class GetFilmProfessionCounts : JsonRequestBase<dynamic, JArray>
    {
        public GetFilmProfessionCounts(long movieId) : base(Signature.Create("getFilmProfessionCounts", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(JArray entity)
        {
            return default;
        }
    }
}