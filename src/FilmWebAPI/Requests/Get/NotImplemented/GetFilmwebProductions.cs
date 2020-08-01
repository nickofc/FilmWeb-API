﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.NotImplemented
{
    public class GetFilmWebProductions : RequestBase<dynamic>
    {
        public GetFilmWebProductions(int offset, int limit, string category) : base(Signature.Create("getFilmwebProductions", $@"\{category}\", offset, limit), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}