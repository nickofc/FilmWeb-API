using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFavoriteCinemas : RequestBase<dynamic>
    {
        public GetUserFavoriteCinemas() : base(Signature.Create("getUserFavouriteCinemas", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}