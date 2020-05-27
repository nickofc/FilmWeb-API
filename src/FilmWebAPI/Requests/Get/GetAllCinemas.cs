using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    internal class GetAllCinemas : JsonRequestBase<IReadOnlyCollection<Cinema>, JArray>
    {
        public GetAllCinemas() : base(Signature.Create("getAllCinemas", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<Cinema>> Parse(JArray entity)
        {
            return entity.Skip(1).Select(token =>
            {
                if (!(token is JArray array))
                    return null;

                return new Cinema
                {
                    Id = array[0].ToObject<int>(),
                    Name = array[1].ToObject<string>(),
                    Latitude = array[2].Value<double?>(),
                    Longitude = array[3].Value<double?>(),
                    CityId = array[4].ToObject<int>(),
                    Address = array[5].ToObject<string>(),
                    Phone = array[6].ToObject<string>(),
                };
            }).ToArray();
        }
    }
}