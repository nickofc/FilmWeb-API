using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmWebAPI.Models;
using NUnit.Framework;

namespace FilmWebAPI.Tests
{
    class NewFeaturesTests
    {
        private readonly FilmWeb _filmWeb;
        public NewFeaturesTests()
        {
            this._filmWeb = new FilmWeb();
        }

        [Test]
        [TestCase(816980, PersonType.Rezyser)]
        [TestCase(816980, PersonType.Aktor)]
        public async Task ShouldGetFilmPersons(long filmId, int personType)
        {
            var persons = await _filmWeb.GetFilmPersons(filmId, personType, 0);

            Assert.IsTrue(persons.Any());
        }
    }
}
