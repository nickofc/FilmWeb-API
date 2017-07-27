using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetCinemaRepertoireDays : RequestBase<dynamic>
    {
        public GetCinemaRepertoireDays(long cinemaId) : base(Signature.Create("getCinemaRepertoireDays", cinemaId.ToString()), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
