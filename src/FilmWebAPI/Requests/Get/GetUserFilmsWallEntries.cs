﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserFilmsWallEntries : RequestBase<dynamic>
    {
        public GetUserFilmsWallEntries() : base(Signature.Create("getUserFilmsWallEntries"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}