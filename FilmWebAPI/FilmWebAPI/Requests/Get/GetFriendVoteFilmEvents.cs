using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFriendVoteFilmEvents : RequestBase<dynamic>
    {
        public GetFriendVoteFilmEvents(int page) : base(Signature.Create("getFriendVoteFilmEvents", page), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}