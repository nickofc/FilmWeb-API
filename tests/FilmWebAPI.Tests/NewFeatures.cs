using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

           
            

        }
    }
}
