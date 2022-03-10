using MegoTravelTest.Logic.Abstractions;

namespace MegoTravelTest.Logic.ExternalSearches;

public class ExternalSearchB : ExternalSearchBase
{
    public ExternalSearchB()
    {
        base._url = "https://yandex.ru/";
    }
}