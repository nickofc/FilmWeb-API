using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
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