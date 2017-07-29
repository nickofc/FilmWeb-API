using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUnreadFriendVoteFilmEventsCount : RequestBase<dynamic>
    {
        public GetUnreadFriendVoteFilmEventsCount() : base(Signature.Create("getUnreadFriendVoteFilmEventsCount"), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}