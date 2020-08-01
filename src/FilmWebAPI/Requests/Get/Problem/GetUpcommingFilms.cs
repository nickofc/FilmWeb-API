using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.Problem
{
    public class GetUpcommingFilms : RequestBase<dynamic>
    {
        public GetUpcommingFilms(DateTime time) : base(Signature.Create("getUpcommingFilms", time), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();

            throw new NotImplementedException();
        }
    }
}