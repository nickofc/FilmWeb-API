using System;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.NotWorking
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