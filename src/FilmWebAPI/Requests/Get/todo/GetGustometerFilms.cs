using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetGustometerFilms : RequestBase<dynamic>
    {
        public GetGustometerFilms(int offset, int limit) : base(Signature.Create("getGustometerFilms", offset, limit), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}