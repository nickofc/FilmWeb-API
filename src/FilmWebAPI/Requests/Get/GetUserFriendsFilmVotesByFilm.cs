using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetUserFriendsFilmVotesByFilm : RequestBase<dynamic>
    {
        public GetUserFriendsFilmVotesByFilm(long movieId) : base(Signature.Create("getUserFriendsFilmVotesByFilm", movieId, null), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}