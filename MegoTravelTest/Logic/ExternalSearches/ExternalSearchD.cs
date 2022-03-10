using MegoTravelTest.Logic.Abstractions;

namespace MegoTravelTest.Logic.ExternalSearches;

public class ExternalSearchD : ExternalSearchBase
{
    public ExternalSearchD()
    {
        base._url = "https://www.bing.com/";
    }
}