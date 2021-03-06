﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmWebAPI.Requests.Get
{
    public class GetUserPersonVotes : RequestBase<dynamic>
    {
        public GetUserPersonVotes() : base(Signature.Create("getUserPersonVotes"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}