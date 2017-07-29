using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFilmWantToSeeDetails : RequestBase<dynamic>
    {

        //return new StringBuilder(getMethodName()).append(" [").append(this.pageNo * 20).append(",").append(20).append(",").append(UserFilmWantToSeeDetails.typeName(this.type)).append(",").append(this.cityId).append("]").toString();
        public GetUserFilmWantToSeeDetails() : base(Signature.Create("getUserFilmWantToSeeDetails"), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}