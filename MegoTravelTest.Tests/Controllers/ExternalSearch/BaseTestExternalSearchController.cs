using MegoTravelTest.Controllers;
using MegoTravelTest.Repositories.Interfaces;
using Moq;

namespace MegoTravelTest.Tests.Controllers.ExternalSearch;

public class BaseTestExternalSearchController
{
    protected readonly ExternalSearchController _controller;

    protected BaseTestExternalSearchController()
    {
        var mockRepo = new Mock<IExternalSearchRepository>();
        _controller = new ExternalSearchController(mockRepo.Object);
    }
}