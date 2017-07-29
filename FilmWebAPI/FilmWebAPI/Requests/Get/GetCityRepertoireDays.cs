using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetCityRepertoireDays : RequestBase<dynamic>
    {
        public GetCityRepertoireDays(long cityId) : base(Signature.Create("getCityRepertoireDays", cityId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
