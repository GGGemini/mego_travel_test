using MegoTravelTest.Logic.Abstractions;

namespace MegoTravelTest.Logic.ExternalSearches;

public class ExternalSearchD : ExternalSearch
{
    public ExternalSearchD()
    {
        base._url = "https://www.bing.com/";
    }
}