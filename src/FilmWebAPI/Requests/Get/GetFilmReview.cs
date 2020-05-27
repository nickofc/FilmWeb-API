using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmReview : RequestBase<dynamic>
    {
        public GetFilmReview(long movieId) : base(Signature.Create("getFilmReview", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}