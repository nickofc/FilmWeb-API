using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmsNearestBroadcasts : RequestBase<dynamic>
    {
        public GetFilmsNearestBroadcasts(long movieId, int page) : base(Signature.Create($"getFilmsNearestBroadcasts_{movieId}_{page}", movieId, page * 100, (page + 1) * 100), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}