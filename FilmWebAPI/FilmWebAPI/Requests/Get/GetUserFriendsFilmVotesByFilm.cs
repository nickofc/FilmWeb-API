using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFriendsFilmVotesByFilm : RequestBase<dynamic>
    {

        public GetUserFriendsFilmVotesByFilm(long movieId) : base(Signature.Create("getUserFriendsFilmVotesByFilm", movieId, null), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}