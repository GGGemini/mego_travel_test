using System.Collections.Generic;
using MegoTravelTest.Controllers;
using MegoTravelTest.Models.Dtos;
using MegoTravelTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace MegoTravelTest.Tests.Controllers.ExternalSearch;

public class TestBaseExternalSearchControllerSearch : BaseTestExternalSearchController
{
    [Fact]
    public void BadResultFourCount()
    {
        // передаём минимальное значение больше максимального - ошибка
        var actionResult = _controller.Search(80, 10, 5).Result;
        
        Assert.IsType<BadRequestObjectResult>(actionResult);
    }
    
    [Fact]
    public void OkResultFourCount()
    {
        var actionResult = _controller.Search(80, 10, 10).Result;
        
        Assert.IsType<OkObjectResult>(actionResult);
        var okResult = actionResult as OkObjectResult;

        Assert.IsType<List<ExternalSearchDto>>(okResult.Value);
        var values = okResult.Value as List<ExternalSearchDto>;
        
        Assert.Equal(4, values.Count);
    }
    
    [Fact]
    public void OkResultZeroCount()
    {
        // отправили время на выполнение методов меньше, чем они будут выполняться - получим пустой массив
        var actionResult = _controller.Search(80, 100, 100).Result;
        
        Assert.IsType<OkObjectResult>(actionResult);
        var okResult = actionResult as OkObjectResult;

        Assert.IsType<List<ExternalSearchDto>>(okResult.Value);
        var values = okResult.Value as List<ExternalSearchDto>;
        
        Assert.Equal(0, values.Count);
    }
}