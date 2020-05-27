using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmDescription : JsonRequestBase<string, JArray>
    {
        public GetFilmDescription(ulong movieId)
            : base(Signature.Create("getFilmDescription", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<string> Parse(JArray entity)
        {
            var description = entity.ToString().Trim("\r\n[] \"".ToCharArray())
                .Replace("\\\"", "\"")
                .Replace("\\n", "\n");

            return description != "null" ? description : string.Empty;
        }
    }
}