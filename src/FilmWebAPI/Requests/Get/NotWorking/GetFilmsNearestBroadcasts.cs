using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
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