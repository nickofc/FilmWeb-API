using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmUserConnectionsCount : RequestBase<dynamic>
    {
        public GetFilmUserConnectionsCount(long movieId) : base(Signature.Create("getFilmUserConnectionsCount", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override System.Threading.Tasks.Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
