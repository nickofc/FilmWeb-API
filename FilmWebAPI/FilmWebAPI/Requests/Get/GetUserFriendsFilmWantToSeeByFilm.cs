using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFriendsFilmWantToSeeByFilm : RequestBase<dynamic>
    {
        public GetUserFriendsFilmWantToSeeByFilm(long movieId) : base(Signature.Create("getUserFriendsFilmWantToSeeByFilm", movieId, null), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}