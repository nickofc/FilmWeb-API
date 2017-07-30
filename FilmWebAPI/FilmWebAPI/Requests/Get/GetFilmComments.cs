using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    //[Obsolete("Prawdobodobnie FilmWebAPI nie obsługuje tej metody!", true)]
    public class GetFilmComments : RequestBase<dynamic>
    {
        public GetFilmComments(long movieId, int pageId) : base(Signature.Create($"getFilmComments", movieId, pageId * 5, (pageId + 1) * 5), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
