using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI;
using FilmWebAPI.Requests.Get;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
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

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                Assert.Fail("Podaj dane do logowania!");


            var loginResult = await FilmWeb.Login(username, password);
            Assert.IsNotNull(loginResult, "loginResult != null");


            // próba logowania z nie prawid³owym has³em / loginem
            await Assert.ThrowsExceptionAsync<FilmWebException>(async () => await FilmWeb.Login("username", "password"));
        }

        [TestMethod]
        public async Task GenerateCaptchaTests()
        {
   
        }


        [TestMethod]
        public async Task GetAllCinemasTests()
        {
            var cinemas = await FilmWeb.GetAllCinemas();
            Assert.IsTrue(cinemas.Any(), "cinemas.Any()");
        }


    }
}