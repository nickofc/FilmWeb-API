using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUpcommingFilms : RequestBase<dynamic>
    {
        public GetUpcommingFilms(DateTime time) : base(Signature.Create("getUpcommingFilms", time), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}