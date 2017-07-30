using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

        [Fact]
        public async Task LoginTests()
        {
            string username = "";
            string password = "";

            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password))
            {
                var result = await _filmWeb.Login(username, password);  
                Assert.NotNull(result);
                Assert.NotNull(result.Birthday);
                Assert.NotNull(result.Id);
                Assert.NotNull(result.Name);
                Assert.NotNull(result.Nick);
                Assert.NotNull(result.Sex);
            }
            else
            {
                Debug.WriteLine($"{nameof(username)} or {nameof(password)} is empty!");
            }

            // próba logowania z nie prawid³owym has³em / loginem
            await Assert.ThrowsAsync<FilmWebException>(async () => await _filmWeb.Login("username", "password"));
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
