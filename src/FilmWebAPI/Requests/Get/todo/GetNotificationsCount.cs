using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetNotificationsCount : RequestBase<dynamic>
    {
        public GetNotificationsCount() : base(Signature.Create("getUnreadNotificationsCount"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}