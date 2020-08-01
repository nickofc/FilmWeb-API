using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get.NotWorking
{
    public class GetFilmsInfoShort : JsonRequestBase<dynamic, JArray>
    {
        public GetFilmsInfoShort(long movieId) : base(Signature.Create("getFilmsInfoShort", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(JArray entity)
        {
            return default;
        }
    }
}