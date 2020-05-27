using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    // nie zwraca danych (samo ok - może zły id)
    internal class GetCinemaRepertoireDays : RequestBase<dynamic>
    {
        public GetCinemaRepertoireDays(ulong cinemaId) : base(Signature.Create("getCinemaRepertoireDays"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}