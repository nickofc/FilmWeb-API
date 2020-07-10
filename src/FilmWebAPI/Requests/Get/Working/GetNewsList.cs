using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests.Get.Working
{
    public class GetNewsList : JsonRequestBase<IReadOnlyCollection<NewsListItem>, JArray>
    {
        public GetNewsList(uint page) : base(Signature.Create("getNewsList", page), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<NewsListItem>> Parse(JArray entity)
        {
            return entity.Select(token => new NewsListItem
            {
                Id = token[0]?.ToObject<int>() ?? default,
                Title = token[1]?.ToObject<string>() ?? string.Empty,
                ShortBody = token[2]?.ToObject<string>() ?? string.Empty,
                CreatedAt = DateTimeEx.GetFromUnixTime(token[3]?.ToObject<long>() ?? 0),
                Image = Safe.ToUrl(token[4]?.ToObject<string>() ?? string.Empty),
                BackingFieldType = token[5]?.ToObject<string>() ?? string.Empty
            }).ToArray();
        }
    }
}