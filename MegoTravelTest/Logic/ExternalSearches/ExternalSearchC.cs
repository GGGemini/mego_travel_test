using MegoTravelTest.Logic.Abstractions;

namespace MegoTravelTest.Logic.ExternalSearches;

public class ExternalSearchC : ExternalSearch
{
    public ExternalSearchC()
    {
        base._url = "https://www.yahoo.com/";
    }
}