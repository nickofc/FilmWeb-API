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
        [TestCase(998, PersonType.Aktor)]
        public async Task ShouldGetFilmPersons(long filmId, PersonType personType)
        {
            var persons = await _filmWeb.GetFilmPersons(filmId, personType, 0);
            Assert.IsTrue(persons.Any());
        }

        [Test]
        [TestCase("CHILLING ADVENTURES OF SABRINA", 800447UL)]
        [TestCase("Forrest Gump", 998UL)]
        public async Task ShouldFindMovieId(string movieTitle, ulong expectedId)
        {
            var movieId = await _filmWeb.GetMovieId(movieTitle);
            Assert.AreEqual(expectedId, movieId.Value);
        }
    }
}