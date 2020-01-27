using FilmWebAPI.Models;
using NUnit.Framework;
using System;
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
        [TestCase(816980, PersonType.Rezyser, 1)]
        [TestCase(816980, PersonType.Scenarzysta, 2)]
        [TestCase(816980, PersonType.Aktor, 53)]
        [TestCase(998, PersonType.Aktor, 142)]
        [TestCase(724464, PersonType.Rezyser, 5)]
        public async Task ShouldGetFilmPersons(long movieId, PersonType personType, int expectedCount)
        {
            var persons = await _filmWeb.GetFilmPersons((ulong)movieId, personType, 0);
            Assert.AreEqual(expectedCount, persons.Count);
        }

        [Test]
        [TestCase("CHILLING ADVENTURES OF SABRINA", 800447)]
        [TestCase("Forrest Gump", 998)]
        [TestCase("Zielona Mila", 862)]
        [TestCase("Cast away", 1470)]
        [TestCase("2 Shrek", 33404)]
        [TestCase("Shrek 2", 33404)]
        public async Task ShouldFindMovieId(string movieTitle, long expectedId)
        {
            var movieId = await _filmWeb.GetMovieId(movieTitle);
            Assert.AreEqual(expectedId, movieId.Value);
        }

        [Test]
        [TestCase(998, "Forrest Gump")]
        [TestCase(862, "Zielona mila")]
        [TestCase(1470, "Cast Away - poza światem")]
        [TestCase(33404, "Shrek 2")]
        [TestCase(810167, "Joker")]
        public async Task ShouldGetPolishTitle(long movieId, string expectedPolishTitle)
        {
            var polishTitle = await _filmWeb.GetFilmPolishTitle((ulong)movieId);
            Assert.AreEqual(expectedPolishTitle, polishTitle);
        }

        [Test]
        [TestCase(998, "Forrest Gump")]
        [TestCase(862, "The Green Mile")]
        [TestCase(1470, "Cast Away")]
        [TestCase(33404, "")] // Shrek 2
        [TestCase(810167, "")]
        public async Task ShouldGetOriginalTitle(long movieId, string expectedOriginalTitle)
        {
            var originalTitle = await _filmWeb.GetFilmOriginalTitle((ulong)movieId);
            Assert.AreEqual(expectedOriginalTitle, originalTitle);
        }

        [Test]
        [TestCase(1470, 7.5)]
        [TestCase(816980, 7.9)]
        [TestCase(862, 8.6)]
        [TestCase(799827, 9.0)]
        [TestCase(998, 8.5)]
        public async Task ShouldGetAvgVote(long movieId, double expectedVote)
        {
            var avgVote = await _filmWeb.GetFilmAvgVote((ulong)movieId);
            Assert.IsTrue(Math.Abs(avgVote - expectedVote) < 0.9);
        }

        [Test]
        [TestCase(998, new[] { "Dramat", "Komedia" })]
        [TestCase(1470, new[] { "Dramat" })]
        [TestCase(33404, new[] { "Animacja", "Familijny", "Komedia" })]
        [TestCase(724464, new[] { "Fantasy", "Przygodowy" })]
        public async Task ShouldGetGenres(long movieId, string[] expectedGenres)
        {
            var genres = await _filmWeb.GetFilmGenres((ulong)movieId);
            Assert.AreEqual(expectedGenres, genres);
        }

        [Test]
        [TestCase(998, new[] { "USA" })]
        [TestCase(816980, new[] { "USA", "Wielka Brytania" })]
        [TestCase(810167, new[] { "Kanada", "USA" })]
        [TestCase(724464, new[] { "Polska", "USA" })]
        public async Task ShouldGetProductionCountries(long movieId, string[] expectedCountries)
        {
            var countries = await _filmWeb.GetFilmProductionCountries((ulong)movieId);
            Assert.AreEqual(expectedCountries, countries);
        }

    }
}