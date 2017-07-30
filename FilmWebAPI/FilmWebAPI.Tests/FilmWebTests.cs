using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilmWebAPI.Tests
{
    [TestClass]
    public class FilmWebTests
    {
        public FilmWeb FilmWeb = new FilmWeb();

        [TestMethod]
        public async Task LoginTests()
        {
            string username = "";
            string password = "";

            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password))
            {
                var loginResult = await FilmWeb.Login(username, password);
                Assert.IsNotNull(loginResult, "loginResult != null");
            }
            else
            {
                Debug.WriteLine($"{nameof(username)} or {nameof(password)} is empty!");
            }

            // próba logowania z nie prawid³owym has³em / loginem
            await Assert.ThrowsExceptionAsync<FilmWebException>(async () => await FilmWeb.Login("username", "password"));
        }

        [TestMethod]
        public async Task GetAllCinemasTests()
        {
            var cinemas = await FilmWeb.GetAllCinemas();
            Assert.IsTrue(cinemas.Any(), "cinemas.Any()");
        }
    }
}
