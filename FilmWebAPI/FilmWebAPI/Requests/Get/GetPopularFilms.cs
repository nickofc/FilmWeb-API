using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetPopularFilms : RequestBase<dynamic>
    {
        public GetPopularFilms() : base(Signature.Create("getPopularFilms"), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}