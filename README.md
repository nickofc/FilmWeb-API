# FilmWebAPI [![Build status](https://ci.appveyor.com/api/projects/status/bes1sload217ypag/branch/master?svg=true)](https://ci.appveyor.com/project/nickofc/filmweb-api/branch/master)


Nieoficjalny klient API 

Na razie biblioteka obsługuje tylko pare funkcji, planuje dopisać reszte, myśle że niebawem to się stanie.
Metod do napisania jest około 80 więc troche pracy jest.
Wszystkie działające funkcje są zawarte w testach.

https://www.nuget.org/packages/FilmWebAPI/  
Install-Package FilmWebAPI


Przykład:  
```
var filmWeb = new FilmWeb();  

var channels  = await filmWeb.GetAllChannels();  
foreach (var channel in channels)  
{
    Console.WriteLine(channel.Name);  
}  
```
