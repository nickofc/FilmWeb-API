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
        [TestCase(810167, PersonType.Muzyka, 1)]
        public async Task ShouldGetFilmPersons(long movieId, PersonType personType, int expectedCount)
        {
            var persons = await _filmWeb.GetFilmPersons((ulong)movieId, personType, 0);
            Assert.AreEqual(expectedCount, persons.Count);
        }

        [Test]
        [TestCase(810167, PersonType.Aktor, "Robert De Niro")]
        [TestCase(810167, PersonType.Rezyser, "Todd Phillips")]
        [TestCase(810167, PersonType.Scenarzysta, "Todd Phillips")]
        [TestCase(810167, PersonType.Scenarzysta, "Scott Silver")]
        [TestCase(810167, PersonType.Zdjecia, "Lawrence Sher")]
        [TestCase(810167, PersonType.Muzyka, "Hildur Guðnadóttir")]
        [TestCase(810167, PersonType.MaterialyDoScenariusza, "Bob Kane")]
        [TestCase(810167, PersonType.Montaz, "Jeff Groth")]
        [TestCase(810167, PersonType.Producent, "Bradley Cooper")]
        public async Task ShouldGetFilmPerson(long movieId, PersonType personType, string expectedPerson)
        {
            var persons = await _filmWeb.GetFilmPersons((ulong)movieId, personType, 0);
            Assert.IsTrue(persons.Any(x => x.Name == expectedPerson));
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

        [Test]
        [TestCase(998, 142)]
        [TestCase(816980, 119)]
        [TestCase(810167, 122)]
        [TestCase(724464, 60)]
        public async Task ShouldGetDuration(long movieId, int expectedNumberOfMinutes)
        {
            var duration = await _filmWeb.GetFilmDuration((ulong)movieId);
            var expectedTimeSpan = TimeSpan.FromMinutes(expectedNumberOfMinutes);
            Assert.AreEqual(expectedTimeSpan, duration);
        }

        [Test]
        [TestCase(998, "world", "1994-06-23")]
        [TestCase(816980, "country", "2020-01-24")]
        [TestCase(816980, "world", "2019-12-25")]
        [TestCase(810167, "world", "2019-08-31")]
        public async Task ShouldGetPremieres(long movieId, string country, string expectedPremierDate)
        {
            var premieres = await _filmWeb.GetFilmPremieres((ulong)movieId);
            var premiereInAskedPlace = premieres.First(x => x.Key == country);

            var expectedDate = DateTime.Parse(expectedPremierDate);
            Assert.AreEqual(expectedDate, premiereInAskedPlace.Value);
        }

        [Test]
        [TestCase(810167, "Strudzony życiem komik popada w obłęd i staje się psychopatycznym mordercą.")]
        [TestCase(998, "Historia życia Forresta, chłopca o niskim ilorazie inteligencji z niedowładem kończyn, który staje się miliarderem i bohaterem wojny w Wietnamie.")]
        [TestCase(724464, "Wiedźmin Geralt, zmutowany łowca potworów, szuka swojego miejsca w świecie, gdzie ludzie często okazują się gorsi niż najstraszniejsze monstra.")]
        public async Task ShouldGetShortDescription(long movieId, string expectedShortDescription)
        {
            var shortDescription = await _filmWeb.GetFilmShortDescription((ulong)movieId);
            Assert.AreEqual(expectedShortDescription, shortDescription);
        }

        [Test]
        [TestCase(810167, "Historia jednego z cieszących się najgorszą sławą superprzestępców uniwersum DC — Jokera. Przedstawiony przez Phillipsa obraz śledzi losy kultowego czarnego charakteru, człowieka zepchniętego na margines. To nie tylko kontrowersyjne studium postaci, ale także opowieść ku przestrodze w szerszym kontekście.")]
        [TestCase(998, "\"Forrest Gump\" to romantyczna historia, w której Tom Hanks wcielił się w tytułową postać - nierozgarniętego młodego człowieka o wielkim sercu i zdolności do odnajdywania się w największych wydarzeniach w historii USA, począwszy od swego dzieciństwa w latach 50-tych. Po tym, jak staje się gwiazdą footballu, odznaczonym bohaterem wojennym i odnoszącym sukcesy biznesmenem, główny bohater zyskuje status osobistości, lecz nigdy nie rezygnuje z poszukiwania tego, co dla niego najważniejsze - miłości swej przyjaciółki, Jenny Curran.\n\nForrest jest małym chłopcem, kiedy jego ojciec porzuca rodzinę, a matka utrzymuje siebie i syna biorąc pod swój dach lokatorów. Kiedy okazuje się, że jej chłopiec ma bardzo niski iloraz inteligencji, pozostaje nieustraszona w swoim przekonaniu, że ma on takie same możliwości, jak każdy inny. To prawda - takie same, a nawet dużo większe. W całym swym życiu Forrest niezamierzenie znajduje się twarzą w twarz z wieloma legendarnymi postaciami lat 50-tych, 60-tych i 70-tych. Wiedzie go to na boisko piłki nożnej, poprzez dżungle Wietnamu, Waszyngton, Chiny, Nowy Jork, do Luizjany i w wiele innych miejsc, a wszystko to relacjonuje on w swych poruszających i wstrząsających opowieściach przypadkowo spotkanym osobom.")]
        [TestCase(724464, "\"Wiedźmin\" to epicka opowieść na podstawie kultowej sagi fantasy Andrzeja Sapkowskiego. Geralt z Rivii, samotny zabójca potworów, usiłuje odnaleźć się w świecie, w którym ludzie bywają gorsi niż bestie, na które poluje. Przeznaczenie splata jego losy z potężną czarodziejką i skrywającą groźną tajemnicę młodą księżniczką. Razem muszą stawić czoła licznym zagrożeniom na pogrążającym się w chaosie Kontynencie.")]
        public async Task ShouldGetDescription(long movieId, string expectedDescription)
        {
            var description = await _filmWeb.GetFilmDescription((ulong)movieId);
            Assert.AreEqual(expectedDescription, description);
        }

        [Test]
        [TestCase(724464, 111003U)]
        [TestCase(816980, 11189U)]
        [TestCase(810167, 181078U)]
        [TestCase(799827, 140533U)]
        public async Task ShouldGetVotesCount(long movieId, ulong expectedVotesCount)
        {
            var votesCount = await _filmWeb.GetFilmVotesCount((ulong)movieId);
            Assert.GreaterOrEqual(votesCount, expectedVotesCount);
        }

        [Test]
        [TestCase(799827, "https://mm.filmweb.pl/799827/chernobyl__2019__official_trailer_hbo.iphone.mp4")]
        public async Task ShouldGetVideoUrls(long movieId, string expectedUrl)
        {
            var videosUrl = await _filmWeb.GetFilmVideosUrls((ulong)movieId);
            Assert.Contains(expectedUrl, videosUrl.ToList());
        }

        [Test]
        [TestCase(799827, 5)]
        public async Task ShouldGetEpisodes(long movieId, int expectedEpisodes)
        {
            var episodesCount = await _filmWeb.GetFilmEpisodesCount((ulong) movieId);
            Assert.AreEqual(expectedEpisodes, episodesCount);
        }

        [Test]
        [TestCase(799827, 0)]
        public async Task ShouldGetSeasons(long movieId, int expectedSeasons)
        {
            var seasonsCount = await _filmWeb.GetFilmSeasonsCount((ulong) movieId);
            Assert.AreEqual(expectedSeasons, seasonsCount);
        }


    }
}