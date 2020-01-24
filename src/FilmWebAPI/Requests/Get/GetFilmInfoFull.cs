using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmInfoFull : RequestBase<dynamic>
    {
        public GetFilmInfoFull(long movieId) : base(Signature.Create("getFilmInfoFull", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}