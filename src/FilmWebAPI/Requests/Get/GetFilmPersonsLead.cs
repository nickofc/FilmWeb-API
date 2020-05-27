using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFilmPersonsLead : RequestBase<dynamic>
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