using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
