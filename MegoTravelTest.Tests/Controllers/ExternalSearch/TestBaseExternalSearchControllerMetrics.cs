using System;
using System.Collections.Generic;
using MegoTravelTest.Controllers;
using MegoTravelTest.Models.Dtos;
using MegoTravelTest.Models.Dtos.Base;
using MegoTravelTest.Models.Dtos.ExternalSearchMetric;
using MegoTravelTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace MegoTravelTest.Tests.Controllers.ExternalSearch;

public class TestBaseExternalSearchControllerMetrics : BaseTestExternalSearchController
{
    [Fact]
    public void BadResultFourCount()
    {
        var startDate = new DateTime(2022, 3, 10);
        var endDate = new DateTime(2022, 3, 10);
        
        var actionResult = _controller.Metrics(startDate, endDate);
        
        Assert.IsType<OkObjectResult>(actionResult);
        var okResult = actionResult as OkObjectResult;
        
        Assert.IsType<List<DateDtosDto<ExternalSearchMetricDto>>>(okResult.Value);
    }
}