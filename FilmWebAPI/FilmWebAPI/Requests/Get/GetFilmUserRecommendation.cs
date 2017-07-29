using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmUserRecommendation : RequestBase<dynamic>
    {
        public GetFilmUserRecommendation(long movieId) : base(Signature.Create("getFilmUserRecommendation", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override System.Threading.Tasks.Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
