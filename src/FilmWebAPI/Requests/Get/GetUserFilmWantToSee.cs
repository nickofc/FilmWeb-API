﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get
{
    internal class GetUserFilmWantToSee : RequestBase<dynamic>
    {
        public GetUserFilmWantToSee() : base(Signature.Create("getUserFilmsWantToSee"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}