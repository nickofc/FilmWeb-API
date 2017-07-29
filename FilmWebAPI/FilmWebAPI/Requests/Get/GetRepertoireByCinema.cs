using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetRepertoireByCinema : RequestBase<dynamic>
    {
        public GetRepertoireByCinema(long cinemaId, DateTime time) : base(Signature.Create("getRepertoireByCinema", cinemaId, time), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}