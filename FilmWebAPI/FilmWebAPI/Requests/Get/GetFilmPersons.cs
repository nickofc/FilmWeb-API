using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmPersons : RequestBase<dynamic>
    {
        public GetFilmPersons(long movieId, int type, int pageId) : base(Signature.Create($"getFilmPersons_{movieId}_{type}_{pageId}"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
