using MegoTravelTest.Logic.Abstractions;

namespace MegoTravelTest.Logic.ExternalSearches;

public class ExternalSearchB : ExternalSearch
{
    public ExternalSearchB()
    {
        base._url = "https://yandex.ru/";
    }
}