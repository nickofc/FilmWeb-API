using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmVideos : RequestBase<dynamic>
    {
        public GetFilmVideos(long movieId, int page) : base(Signature.Create($"getFilmVideos_{movieId}_{page}", movieId, page * 100, (page + 1) * 100 ), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
