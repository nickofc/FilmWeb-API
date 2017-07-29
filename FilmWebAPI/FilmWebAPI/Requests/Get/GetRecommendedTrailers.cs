using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetRecommendedTrailers : RequestBase<dynamic>
    {
        public GetRecommendedTrailers() : base(Signature.Create("getRecommendedTrailers"), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}