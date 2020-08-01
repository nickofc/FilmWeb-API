using System;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.NotWorking
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