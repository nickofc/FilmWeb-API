using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFriendsPersonVotesByPerson : RequestBase<dynamic>
    {
        public GetUserFriendsPersonVotesByPerson(long personId) : base(Signature.Create("getUserFriendsPersonVotesByPerson", personId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}