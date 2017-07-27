using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmComments : RequestBase<dynamic>
    {
        //protected String createApiSignature()
        //{
        //    return getMethodName() + " [" + this.filmId + "," + (this.pageNo * 5) + "," + ((this.pageNo + 1) * 5) + "]";
        //}
        public GetFilmComments(long movieId, int pageId) : base(Signature.Create($"getFilmComments_{movieId}_{pageId}"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
