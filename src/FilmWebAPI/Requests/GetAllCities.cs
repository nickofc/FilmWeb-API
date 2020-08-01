using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests
{
    public class GetAllCities : JsonRequestBase<IReadOnlyCollection<City>, JArray>
    {
        public GetAllCities() : base(Signature.Create("getAllCities", -1), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<City>> Parse(JArray entity)
        {
            return entity.Select(token =>
            {
                if (!(token is JArray array))
                    return null;

                return new City
                {
                    Id = array[0].ToObject<int>(),
                    Name = array[1].ToObject<string>()
                };
            }).ToArray();
        }
    }
}