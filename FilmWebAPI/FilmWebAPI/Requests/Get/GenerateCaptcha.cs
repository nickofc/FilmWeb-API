using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    [Obsolete("Nie potrzeba używać tej klasy.", true)]
    public class GenerateCaptcha : RequestBase<dynamic>
    {
        public GenerateCaptcha() : base(Signature.Create("generateCaptcha"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
