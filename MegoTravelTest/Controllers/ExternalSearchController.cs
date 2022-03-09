using MegoTravelTest.Logic.ExternalSearches;
using MegoTravelTest.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MegoTravelTest.Controllers;

[ApiController]
[Route("external_search")]
public class ExternalSearchController : ControllerBase
{
    [HttpGet("search")]
    public IActionResult Search(int wait, int randomMin, int randomMax)
    {
        var searchA = new ExternalSearchA();
        var searchB = new ExternalSearchB();
        var searchC = new ExternalSearchC();
        var searchD = new ExternalSearchD();

        var searchTaskC = new Task<ResultDto>(() => searchC.Request(randomMin, randomMax));
        var searchTaskD = searchTaskC.ContinueWith(t => searchD.Request(randomMin, randomMax));

        var tasks = new List<Task<ResultDto>>
        {
            new Task<ResultDto>(() => searchA.Request(randomMin, randomMax)),
            new Task<ResultDto>(() => searchB.Request(randomMin, randomMax)),
            searchTaskC
        };
        tasks.ForEach(t =>
        {
            t.Start();
            t.Wait(wait);
        });
        
        tasks.Add(searchTaskD);
        
        searchTaskD.Wait(wait);

        Task.WhenAll(tasks).Wait();

        var result = new List<ResultDto>(tasks.Select(x => x.Result));
        
        return Ok(result);
    }
}