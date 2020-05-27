using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetCinemaRepertoireDays : RequestBase<dynamic>
    {
        public GetCinemaRepertoireDays(long cinemaId) : base(Signature.Create("getCinemaRepertoireDays"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}