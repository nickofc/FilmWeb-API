using System;
using System.Net.Http;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmUserRecommendation : RequestBase<dynamic>
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