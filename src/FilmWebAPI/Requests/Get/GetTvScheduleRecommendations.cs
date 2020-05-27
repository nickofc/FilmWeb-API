using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetTvScheduleRecommendations : RequestBase<dynamic>
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