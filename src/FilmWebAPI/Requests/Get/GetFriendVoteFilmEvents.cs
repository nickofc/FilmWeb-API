using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetFriendVoteFilmEvents : RequestBase<dynamic>
    {
        public GetFriendVoteFilmEvents(int page) : base(Signature.Create("getFriendVoteFilmEvents", page), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}