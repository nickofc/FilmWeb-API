using System;
using System.Net.Http;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmUserConnectionsCount : RequestBase<dynamic>
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