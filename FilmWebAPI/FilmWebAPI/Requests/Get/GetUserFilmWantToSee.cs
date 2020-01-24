using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFilmWantToSee : RequestBase<dynamic>
    {
        public GetUserFilmWantToSee() : base(Signature.Create("getUserFilmsWantToSee"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}