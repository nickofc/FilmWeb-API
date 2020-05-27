using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmOriginalTitle : JsonRequestBase<string, JArray>
    {

        public GetFilmOriginalTitle(ulong movieId)
            : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<string> Parse(JArray entity)
        {
            const int ORIGINAL_TITLE_INDEX = 1;
            return entity[ORIGINAL_TITLE_INDEX].ToString();
        }
    }
}
