using FilmWebAPI.Models;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FilmWebAPI.Tests
{
    internal class NewFeaturesTests
    {
        private readonly FilmWeb _filmWeb;

        public NewFeaturesTests()
        {
            _filmWeb = new FilmWeb();
        }

        [Test]
        [TestCase(816980, PersonType.Rezyser)]
        [TestCase(816980, PersonType.Aktor)]
        public async Task ShouldGetFilmPersons(long filmId, PersonType personType)
        {
            var persons = await _filmWeb.GetFilmPersons(filmId, personType, 0);

            Assert.IsTrue(persons.Any());
        }
    }
}