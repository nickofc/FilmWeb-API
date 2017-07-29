using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmwebProductions : RequestBase<dynamic>
    {
        public GetFilmwebProductions(int offset, int limit, string category) : base(Signature.Create("getFilmwebProductions", $@"\{category}\", offset, limit), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
