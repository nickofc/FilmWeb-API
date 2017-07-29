using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFriends : RequestBase<dynamic>
    {

        public GetUserFriends() : base(Signature.Create("getUserFriends"), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}