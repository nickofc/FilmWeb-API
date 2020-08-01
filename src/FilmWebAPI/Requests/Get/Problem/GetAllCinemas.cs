using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get.Problem
{
    /* zwraca jeden wynik */
    public class GetAllCinemas : JsonRequestBase<IReadOnlyCollection<Cinema>, JArray>
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
                    Location = new Location(array[2].Value<double>(), 
                        array[3].Value<double>()),
                    CityId = array[4].ToObject<int>(),
                    Address = array[5].ToObject<string>(),
                    Phone = array[6].ToObject<string>(),
                };
            }).ToArray();
        }
    }
}