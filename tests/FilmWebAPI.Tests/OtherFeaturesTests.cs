using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FilmWebAPI.Tests
{
    public class OtherFeaturesTests
    {
        private readonly FilmWeb _filmWeb;

        public OtherFeaturesTests()
        {
            _filmWeb = new FilmWeb();
        }

        [Ignore("Method Login isn't used anywhere and it's not always working")]
        [Theory]
        [TestCase("fake-user", "fake-pass", false)]
        public async Task LoginTests(string username, string password, bool expectedResult)
        {
            //var result = await _filmWeb.Login(username, password);
            //Assert.AreEqual(result.IsLoggedIn, expectedResult);
        }

        [Test]
        public async Task GetAllChannelsTests()
        {
            var channels = await _filmWeb.GetAllChannels();
            Assert.True(channels.Any());
        }

        [Test]
        public async Task GetAllCitiesTests()
        {
            var cities = await _filmWeb.GetAllCities();
            Assert.True(cities.Any());
        }

        [Test]
        public async Task GetBornTodayPersonsTests()
        {
            var birthdates = await _filmWeb.GetBornTodayPersons();
            Assert.True(birthdates.Any());
        }
    }
}