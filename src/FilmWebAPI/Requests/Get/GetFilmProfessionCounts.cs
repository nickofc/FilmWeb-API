using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmProfessionCounts : RequestBase<dynamic>
    {
        public GetFilmProfessionCounts(long movieId) : base(Signature.Create("getFilmProfessionCounts", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}