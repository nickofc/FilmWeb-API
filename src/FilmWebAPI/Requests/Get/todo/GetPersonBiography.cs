using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetPersonBiography : RequestBase<dynamic>
    {
        public GetPersonBiography(long personId, int filmType, int type, int offset, int limit) : base(Signature.Create("getPersonFilms", personId, filmType, type, offset, limit), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}