using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetPersonInfoFull : RequestBase<dynamic>
    {
        public GetPersonInfoFull(long personId) : base(Signature.Create("getPersonInfoFull", personId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}