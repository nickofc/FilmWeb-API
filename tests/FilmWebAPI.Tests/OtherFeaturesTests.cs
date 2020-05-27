using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FilmWebAPI.Tests
{
    public class OtherFeaturesTests
    {
        private readonly FilmWebApi _filmWebApi;

        public OtherFeaturesTests()
        {
            _filmWebApi = new FilmWebApi();
        }

       // [Ignore("Method Login isn't used anywhere and it's not always working")]
        [Theory]
        [TestCase("fake-user", "fake-pass", false)]
        public async Task LoginTests(string username, string password, bool expectedResult)
        {
            var result = await _filmWebApi.Login(username, password);
            Assert.AreEqual(result.IsLoggedIn, expectedResult);
        }

        [Test]
        public async Task GetAllChannelsTests()
        {
            var channels = await _filmWebApi.GetAllChannels();
            Assert.True(channels.Any());
        }

        [Test]
        public async Task GetAllCitiesTests()
        {
            var cities = await _filmWebApi.GetAllCities();
            Assert.True(cities.Any());
        }

        [Test]
        public async Task GetBornTodayPersonsTests()
        {
            var birthdates = await _filmWebApi.GetBornTodayPersons();
            Assert.True(birthdates.Any());
        }
    }
}