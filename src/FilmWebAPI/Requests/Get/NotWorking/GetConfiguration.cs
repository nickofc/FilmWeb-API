using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetConfiguration : ContentRequestBase<dynamic>
    {
        public GetConfiguration(string name) : base(Signature.Create("getConfiguration", name), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(string content)
        {
            throw new NotImplementedException();
        }
    }
}