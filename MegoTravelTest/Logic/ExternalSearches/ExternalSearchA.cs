using MegoTravelTest.Logic.Abstractions;
using MegoTravelTest.Models.Dtos;

namespace MegoTravelTest.Logic.ExternalSearches;

public class ExternalSearchA : ExternalSearchBase
{
    public ExternalSearchA()
    {
        base._url = "https://www.google.com/";
    }
}