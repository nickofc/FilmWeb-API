﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using Newtonsoft.Json.Linq;

namespace FilmWebAPI.Requests
{
    public class GetFilmVideosUrls : JsonRequestBase<IReadOnlyCollection<string>, JArray>
    {
        public GetFilmVideosUrls(ulong movieId)
            : base(Signature.Create("getFilmVideos", movieId, 0, 10000), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<IReadOnlyCollection<string>> Parse(JArray entity)
        {
            // doesn't work since last api changes - maybe it's possible to fix

            return entity.SelectMany(x => x.Where(u => u.ToString().Contains(".mp4")))
                .Select(x => x.ToString()).ToArray();
        }
    }
}