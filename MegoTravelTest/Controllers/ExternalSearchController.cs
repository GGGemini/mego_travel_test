using MegoTravelTest.Extensions;
using MegoTravelTest.Helpers;
using MegoTravelTest.Logic.ExternalSearches;
using MegoTravelTest.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;

namespace MegoTravelTest.Controllers;

[ApiController]
[Route("external_search")]
public class ExternalSearchController : ControllerBase
{
    [HttpGet("search")]
    public async Task<IActionResult> Search(int wait, int randomMin, int randomMax)
    {
        try
        {
            // проверка пользовательского ввода
            if (randomMin > randomMax)
                return BadRequest("RandomMin more than RandomMax");
            
            var searchA = new ExternalSearchA();
            var searchB = new ExternalSearchB();
            var searchC = new ExternalSearchC();
            var searchD = new ExternalSearchD();

            var funcs = new Func<ResultDto>[]
            {
                () => searchA.Request(randomMin, randomMax),
                () => searchB.Request(randomMin, randomMax),
                () => searchC.Request(randomMin, randomMax)
            };
            var funcD = () => searchD.Request(randomMin, randomMax);

            var taskList = new List<Task<ResultDto>>();

            foreach (var func in funcs)
            {
                var task = new Task<ResultDto>(func);

                var resultDto = TaskHelper.GetResultByTimeout(task, wait);

                taskList.Add(resultDto);
            }
            
            // запускаем функцию D после C
            var taskC = taskList.Last();
            var taskD = taskC.ContinueWith(t => TaskHelper.GetResultByTimeout(new Task<ResultDto>(funcD), wait));
            taskD.Wait();

            // записываем результаты
            var resultList = new List<ResultDto>();
            
            taskList.ForEach(t => resultList.SafeAdd(t.Result));
            resultList.SafeAdd(taskD.Result.Result);

            return Ok(resultList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}