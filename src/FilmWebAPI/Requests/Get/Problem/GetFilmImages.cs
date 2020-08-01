﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;

namespace FilmWebAPI.Requests.Get.Problem
{    // nie zwraca danych (samo ok - może zły id)

    public class GetFilmImages : RequestBase<dynamic>
    {
        public GetFilmImages(long movieId, int pageId) : base(Signature.Create($"getFilmImages_{movieId}_{pageId}"), FilmWebHttpMethod.Get)
        {
        }

        public override async Task<dynamic> Parse(HttpResponseMessage responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}