using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetAllChannels : JsonRequestBase<IReadOnlyCollection<Channel>, JArray>
    {
        public GetAllChannels() : base(Signature.Create("getAllChannels", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<Channel>> Parse(JArray entity)
        {
            return entity.Skip(1).Select(token =>
            {
                if (!(token is JArray array))
                    return null;

                return new Channel
                {
                    Id = array[0].ToObject<int>(),
                    Name = array[1].ToObject<string>(),
                    ImagePath = array[2].ToObject<string>(),
                    DayStartHour = array[3].ToObject<int>(),
                };
            }).ToArray();
        }
    }
}
