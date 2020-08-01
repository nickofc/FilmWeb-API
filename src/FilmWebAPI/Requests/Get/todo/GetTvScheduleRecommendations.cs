using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetTvScheduleRecommendations : RequestBase<dynamic>
    {
        public GetTvScheduleRecommendations(long channelId, DateTime time) : base(Signature.Create("getTvScheduleRecommendations", time, channelId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}