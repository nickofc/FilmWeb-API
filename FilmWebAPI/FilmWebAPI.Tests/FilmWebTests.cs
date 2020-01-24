using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FilmWebAPI.Tests
{
    public class FilmWebTests
    {
        private readonly FilmWeb _filmWeb;

        public FilmWebTests()
        {
            _filmWeb = new FilmWeb();
        }

        [Theory]
        [InlineData("fake-user", "fake-pass", false)]
        public async Task LoginTests(string username, string password, bool expectedResult)
        {
            var result = await _filmWeb.Login(username, password);
            Assert.Equal(result.IsLoggedIn, expectedResult);
        }

        [Fact]
        public async Task GetAllCinemasTests()
        {
            var cinemas = await _filmWeb.GetAllCinemas();
            Assert.True(cinemas.Any());
        }

        [Fact]
        public async Task GetAllChannelsTests()
        {
            var channels = await _filmWeb.GetAllChannels();
            Assert.True(channels.Any());
        }

        [Fact]
        public async Task GetAllCitiesTests()
        {
            var cities = await _filmWeb.GetAllCities();
            Assert.True(cities.Any());
        }

        [Fact]
        public async Task GetBornTodayPersonsTests()
        {
            var birthdates = await _filmWeb.GetBornTodayPersons();
            Assert.True(birthdates.Any());
        }
    }
}