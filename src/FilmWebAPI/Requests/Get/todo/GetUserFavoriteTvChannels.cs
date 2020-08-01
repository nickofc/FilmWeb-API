using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetUserFavoriteTvChannels : RequestBase<dynamic>
    {
        public GetUserFavoriteTvChannels() : base(Signature.Create("getUserFavouriteChannels", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}