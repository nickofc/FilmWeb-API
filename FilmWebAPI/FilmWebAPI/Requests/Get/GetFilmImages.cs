using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmImages : RequestBase<dynamic>
    {
        public GetFilmImages(long movieId, int pageId) : base(Signature.Create($"getFilmImages_{movieId}_{pageId}"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
