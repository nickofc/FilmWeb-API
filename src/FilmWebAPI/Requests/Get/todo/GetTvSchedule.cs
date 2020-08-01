using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetTvSchedule : RequestBase<dynamic>
    {
        public GetTvSchedule(long channelId, DateTime time) : base(Signature.Create("getTvSchedule", channelId, time), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}