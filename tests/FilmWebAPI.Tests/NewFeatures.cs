using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmWebAPI.Core.Communication;
using FilmWebAPI.Models;
using FilmWebAPI.Requests.Get;
using FilmWebAPI.Requests.Get.Working;
using NUnit.Framework;

namespace FilmWebAPI.Tests
{
    public class NewFeatures
    {
        private readonly FilmWebApi _filmWebApi;

        public NewFeatures()
        {
            _filmWebApi = new FilmWebApi();
        }

        [Test]
        public async Task Fun()
        {
            var filmWebApiClient = new FilmWebApiClient();

            var request = new GetNewsList(0);
            var resp = await filmWebApiClient.Dispatch(request, CancellationToken.None);


            var asdf = new GetNews(resp.First().Id);

            var asdff = await filmWebApiClient.Dispatch(asdf);
        }
    }
}
