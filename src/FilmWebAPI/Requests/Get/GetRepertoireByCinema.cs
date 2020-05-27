using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetRepertoireByCinema : RequestBase<dynamic>
    {
        public GetRepertoireByCinema(long cinemaId, DateTime time) : base(Signature.Create("getRepertoireByCinema", cinemaId, time), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}