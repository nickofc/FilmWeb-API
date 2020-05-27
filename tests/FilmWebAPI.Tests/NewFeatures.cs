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
using NUnit.Framework;

namespace FilmWebAPI.Tests
{
    public class NewFeatures
    {
        private readonly IFilmWebApi _filmWebApi;

        public NewFeatures()
        {
            _filmWebApi = new FilmWebApi();
        }

        [Test]
        public async Task Fun()
        {
            var filmWebApiClient = new FilmWebApiClient(FilmWebConfig.Default());

            var request = new LiveSearch("Harry");
                //new GetFilmPersons(30571, PersonType.Aktor, 0);

            var resp = await filmWebApiClient.Dispatch(request, CancellationToken.None);


            // 547
            

        }
    }
}
