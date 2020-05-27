using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;

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