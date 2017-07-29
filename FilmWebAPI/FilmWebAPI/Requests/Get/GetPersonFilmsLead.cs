using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetPersonFilmsLead : RequestBase<dynamic>
    {
        public GetPersonFilmsLead(long personId, int limit) : base(Signature.Create("getPersonFilmsLead", personId, limit), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}