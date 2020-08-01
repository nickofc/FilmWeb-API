using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetFriendVoteFilmEvents : RequestBase<dynamic>
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