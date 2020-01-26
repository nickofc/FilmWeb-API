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
        public async Task ShouldGetFilmPersons(long movieId, PersonType personType)
        {
            var persons = await _filmWeb.GetFilmPersons((ulong)movieId, personType, 0);
            Assert.IsTrue(persons.Any());
        }

        [Test]
        [TestCase("CHILLING ADVENTURES OF SABRINA", 800447)]
        [TestCase("Forrest Gump", 998)]
        [TestCase("Zielona mila", 862)]
        public async Task ShouldFindMovieId(string movieTitle, long expectedId)
        {
            var movieId = await _filmWeb.GetMovieId(movieTitle);
            Assert.AreEqual(expectedId, movieId.Value);
        }

        [Test]
        [TestCase(998, "Forrest Gump")]
        [TestCase(862, "Zielona mila")]
        public async Task ShouldGetPolishTitle(long movieId, string expectedPolishTitle)
        {
            var polishTitle = await _filmWeb.GetPolishTitle((ulong)movieId);
            Assert.AreEqual(expectedPolishTitle, polishTitle);
        }
    }
}