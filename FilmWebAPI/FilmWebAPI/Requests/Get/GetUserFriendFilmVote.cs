using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFriendFilmVote : RequestBase<dynamic>
    {

        public GetUserFriendFilmVote(long movieId, long userId) : base(Signature.Create("getUserFriendsFilmVotesByFilm", movieId, userId), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}