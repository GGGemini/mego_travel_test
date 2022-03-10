using MegoTravelTest.Logic.Abstractions;

namespace MegoTravelTest.Logic.ExternalSearches;

public class ExternalSearchC : ExternalSearchBase
{
    public ExternalSearchC()
    {
        base._url = "https://www.yahoo.com/";
    }
}