[![Build status](https://ci.appveyor.com/api/projects/status/bes1sload217ypag/branch/master?svg=true)](https://ci.appveyor.com/project/nickofc/filmweb-api/branch/master)
[![NuGet](https://img.shields.io/nuget/v/FilmWebAPI.svg)](https://www.nuget.org/packages/FilmWebAPI)

# FilmWebAPI

Nieoficjalny klient API FilmWeba dla C#.  
Obecnie pozwala w łatwy sposób uzyskać podstawowe informacje o filmach na portalu FilmWeb, a w przyszłości może zostać rozbudowany o kolejne funkcje.

## Jak zacząć

### Instalacja

Zacznij od instalacji biblioteki:  
```Install-Package FilmWebAPI```

### Przykład

```
var filmWeb = new FilmWeb();  

var title = await filmweb.GetFilmOriginalTitle(123456789);
Console.WriteLine(title);

var channels = await filmWeb.GetAllChannels();  
foreach (var channel in channels)  
{
    Console.WriteLine(channel.Name);  
}  
```  

## Obecnie zaimplementowane funkcje:  
- **GetAllChannels**()  
- **GetAllCities**()  
- **GetBornTodayPersons**()  
- **GetFilmPersons**(ulong movieId, PersonType personType, int page)  
- **GetMovieId**(string movieTitle)  
- **GetFilmPolishTitle**(ulong movieId)  
- **GetFilmOriginalTitle**(ulong movieId)  
- **GetFilmAvgVote**(ulong movieId)  
- **GetFilmGenres**(ulong movieId)  
- **GetFilmProductionCountries**(ulong movieId)  
- **GetFilmDuration**(ulong movieId)  
- **GetFilmPremieres**(ulong movieId)  
- **GetFilmDescription**(ulong movieId)  
- **GetFilmShortDescription**(ulong movieId)  
- **GetFilmVotesCount**(ulong movieId)  
- **GetFilmEpisodesCount**(ulong movieId)  
- **GetFilmSeasonsCount**(ulong movieId)  
- **GetFilmYear**(ulong movieId)  

## Rozwój  
Jeśli uważasz, że ten projekt jest przydatny dla Ciebie, rozważ dodanie nowych funkcji przez Pull Request, dzięki temu biblioteka stanie się bardziej przydatna dla kolejnych osób.  
Kod jest łatwy w zrozumieniu, jak również proste jest samo dodanie kolejnych funkcji. Czasem może to wymagać chwilowego zastanowienia się nad zwracanymi danymi przez API FilmWeba (co nie zawsze jest oczywiste), jednak napisanie większości funkcji będzie polegać na kopiowaniu i wzorowaniu się na już istniejących funkcjach.
