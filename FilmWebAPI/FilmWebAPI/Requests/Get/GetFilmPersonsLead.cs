using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmPersonsLead : RequestBase<dynamic>
    {
        public GetFilmPersonsLead(long movieId, int size) : base(Signature.Create("getFilmPersonsLead", movieId, size), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
