using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetRecommendedTrailers : RequestBase<dynamic>
    {
        public GetRecommendedTrailers() : base(Signature.Create("getRecommendedTrailers"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}