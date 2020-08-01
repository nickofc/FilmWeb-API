using System;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.Problem
{
    /* nie zwraca danych */
    public class GetCommingSoon : ContentRequestBase<dynamic>
    {
        public GetCommingSoon() : base(Signature.Create("getUpcommingFilms"), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(string content)
        {
            throw new NotImplementedException();
        }
    }
}