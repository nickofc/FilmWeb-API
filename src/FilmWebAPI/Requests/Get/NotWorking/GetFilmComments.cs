using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    //[Obsolete("Prawdobodobnie FilmWebAPI nie obsługuje tej metody!", true)]
    public class GetFilmComments : ContentRequestBase<dynamic>
    {
        public GetFilmComments(long movieId, int pageId) : base(Signature.Create($"getFilmComments", movieId, pageId * 5, (pageId + 1) * 5), FilmWebHttpMethod.Get)
        {
        }
        public override Task<dynamic> Parse(string content)
        {
            throw new NotImplementedException();
        }
    }
}