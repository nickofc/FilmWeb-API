using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.Problem
{
    // nie zwraca danych (samo ok - może zły id)
    public class GetCinemaRepertoireDays : RequestBase<dynamic>
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