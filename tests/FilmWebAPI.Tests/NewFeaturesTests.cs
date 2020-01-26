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
        [TestCase("Zielona Mila", 862)]
        [TestCase("Cast away", 1470)]
        public async Task ShouldFindMovieId(string movieTitle, long expectedId)
        {
            var movieId = await _filmWeb.GetMovieId(movieTitle);
            Assert.AreEqual(expectedId, movieId.Value);
        }

        [Test]
        [TestCase(998, "Forrest Gump")]
        [TestCase(862, "Zielona mila")]
        [TestCase(1470, "Cast Away - poza światem")]
        public async Task ShouldGetPolishTitle(long movieId, string expectedPolishTitle)
        {
            var polishTitle = await _filmWeb.GetFilmPolishTitle((ulong)movieId);
            Assert.AreEqual(expectedPolishTitle, polishTitle);
        }

        [Test]
        [TestCase(998, "Forrest Gump")]
        [TestCase(862, "The Green Mile")]
        [TestCase(1470, "Cast Away")]
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
        public async Task ShouldGetAvgVote(long movieId, double expectedVote)
        {
            var avgVote = await _filmWeb.GetFilmAvgVote((ulong) movieId);
            Assert.IsTrue(Math.Abs(avgVote - expectedVote) < 0.9);
        }
    }
}