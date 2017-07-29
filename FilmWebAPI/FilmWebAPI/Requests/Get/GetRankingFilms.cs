using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetRankingFilms : RequestBase<dynamic>
    {
        public const string RankingName = "top_100_films_world";
        public GetRankingFilms(int geneId) : base(Signature.Create("getRankingFilms", RankingName, geneId), (RequestBase<dynamic>.FilmWebHttpMethod) RequestBase<dynamic>.FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}