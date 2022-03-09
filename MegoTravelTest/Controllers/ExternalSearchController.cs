using MegoTravelTest.Logic.ExternalSearches;
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

        var searchTaskC = new Task(() => searchC.Request(randomMin, randomMax));
        searchTaskC.ContinueWith(t => searchD.Request(randomMin, randomMax));

        var tasks = new Task[]
        {
            new Task(() => searchA.Request(randomMin, randomMax)),
            new Task(() => searchB.Request(randomMin, randomMax)),
            searchTaskC
        };
        Parallel.ForEach(tasks, t =>
        {
            t.Wait(wait);
            t.Start();
        });
        
        return Ok("Результат");
    }
}