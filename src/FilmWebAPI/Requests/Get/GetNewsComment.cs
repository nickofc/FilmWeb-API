using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetNewsComment : RequestBase<dynamic>
    {
        public GetNewsComment(long newsId, int page) : base(Signature.Create("getNewsComments", newsId, page), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}