using System.Threading.Tasks;
using FilmWebAPI.Core.Common;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;

namespace FilmWebAPI.Requests
{
    public class GetNews : JsonRequestBase<News, string[]>
    {
        private readonly NewsId _newsId;
        public GetNews(long newsId) : base(Signature.Create("getNews", newsId), FilmWebHttpMethod.Get)
        {
            _newsId = newsId;
        }

        public override Task<News> Parse(string[] entity)
        {
            if (entity == null)
            {
                return Task.FromResult<News>(null);
            }

            long.TryParse(entity[3], out var unixTime);

            var news = new News
            {
                Id = _newsId,
                Title = entity[0] ?? string.Empty,
                ShortBody = entity[1] ?? string.Empty,
                FullBody = entity[2] ?? string.Empty,
                CreatedAt = DateTimeEx.GetFromUnixTime(unixTime),
                Image = Core.Common.Parse.Url(entity[4] ?? string.Empty),

                UnknownField1 = entity[5],
                UnknownField2 = entity[6],
                UnknownField3 = entity[7],
            };

            return Task.FromResult(news);
        }
    }
}