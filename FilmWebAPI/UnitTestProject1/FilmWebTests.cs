using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FilmWebAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class FilmWebTests
    {
        public FilmWeb FilmWeb = new FilmWeb();

        [TestMethod]
        public async Task LoginTest()
        {
            string username = "";
            string password = "";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                Assert.Fail("Podaj dane do logowania!");


            var loginResult = await FilmWeb.Login(username, password);
            Assert.IsNotNull(loginResult, "loginResult != null");


            await Assert.ThrowsExceptionAsync<FilmWebException>(async () => await FilmWeb.Login("username", "password"));
        }

        [TestMethod]
        public async Task Getallcinemas()
        {
            var cinemas = await FilmWeb.GetAllCinemas();
            Assert.IsTrue(cinemas.Any(), "cinemas.Any()");
        }


        [TestMethod]
        public async Task GetComments()
        {
             await FilmWeb.GetCommends(57104, 1);

        }
    }
}