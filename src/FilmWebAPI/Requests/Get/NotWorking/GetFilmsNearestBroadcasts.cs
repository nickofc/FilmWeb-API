using System;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get.NotWorking
{
    public class GetFilmsNearestBroadcasts : JsonRequestBase<dynamic, JArray>
    {
        public GetFilmsNearestBroadcasts(long movieId, int page) : base(Signature.Create($"getFilmsNearestBroadcasts_{movieId}_{page}", movieId, page * 100, (page + 1) * 100), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(JArray entity)
        {
            throw new NotImplementedException();
        }
    }
}