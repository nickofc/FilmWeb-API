using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetPersonProfessionCounts : RequestBase<dynamic>
    {
        public GetPersonProfessionCounts(long personId) : base(Signature.Create("getPersonProfessionCounts", personId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}