using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get
{
    public class GetFilmsInfoShort : JsonRequestBase<dynamic, JArray>
    {
        public GetFilmsInfoShort(long movieId) : base(Signature.Create("getFilmsInfoShort", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override Task<dynamic> Parse(JArray entity)
        {
            return default;
        }
    }
}