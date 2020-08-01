using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests
{
    public class GetFilmReview : JsonRequestBase<Review, JArray>
    {
        public GetFilmReview(long movieId) : base(Signature.Create("getFilmReview", movieId), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<Review> Parse(JArray entity)
        {
            return new Review
            {
                Author = entity[0].ToObject<string>(),
                Unk1 = entity[1].ToObject<string>(),
                Unk2 = entity[2].ToObject<string>(),
                Content = entity[3].ToObject<string>(),
                Title = entity[4].ToObject<string>()
            };
        }
    }
}