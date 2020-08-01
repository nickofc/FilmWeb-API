﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.todo
{
    public class GetPersonImages : RequestBase<dynamic>
    {
        public GetPersonImages(long personId, int page) : base(Signature.Create("getPersonImages", personId, page * 100, (page + 1) * 100), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}