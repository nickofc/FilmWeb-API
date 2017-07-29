using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetTvScheduleRecommendations : RequestBase<dynamic>
    {
        public GetTvScheduleRecommendations(long channelId, DateTime time) : base(Signature.Create("getTvScheduleRecommendations", time, channelId), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}