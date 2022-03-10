using MegoTravelTest.Extensions;
using MegoTravelTest.Helpers;
using MegoTravelTest.Logic.ExternalSearches;
using MegoTravelTest.Models.Dtos;
using MegoTravelTest.Models.Dtos.Base;
using MegoTravelTest.Models.Dtos.ExternalSearchMetric;
using MegoTravelTest.Models.Entities;
using MegoTravelTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;

namespace MegoTravelTest.Controllers;

[ApiController]
[Route("external_search")]
public class ExternalSearchController : ControllerBase
{
    private readonly IExternalSearchRepository _externalSearchRepository;
    
    public ExternalSearchController(IExternalSearchRepository externalSearchRepository)
    {
        _externalSearchRepository = externalSearchRepository;
    }
    
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

            var funcs = new Func<ExternalSearchDto>[]
            {
                () => searchA.Request(randomMin, randomMax),
                () => searchB.Request(randomMin, randomMax),
                () => searchC.Request(randomMin, randomMax)
            };
            var funcD = () => searchD.Request(randomMin, randomMax);

            var taskList = new List<Task<ExternalSearchDto>>();

            foreach (var func in funcs)
            {
                var task = new Task<ExternalSearchDto>(func);

                var taskDto = TaskHelper.GetResultByTimeoutAsync(task, wait);

                taskList.Add(taskDto);
            }
            
            // запускаем функцию D после C
            var taskC = taskList.Last();
            var taskD = taskC.ContinueWith(t => TaskHelper.GetResultByTimeoutAsync(new Task<ExternalSearchDto>(funcD), wait));
            taskD.Wait();

            // записываем результаты из таск в выходную модель
            var externalSearchDtos = new List<ExternalSearchDto>();
            taskList.ForEach(t => externalSearchDtos.SafeAdd(t.Result));
            externalSearchDtos.SafeAdd(taskD.Result.Result);
            
            // записываем результаты в базу
            var externalSearches = externalSearchDtos.Select(x => new ExternalSearch(x));
            _externalSearchRepository.Create(externalSearches);

            return Ok(externalSearchDtos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("metrics")]
    public IActionResult Metrics(DateTime startDate, DateTime endDate)
    {
        try
        {
            var externalSearches = _externalSearchRepository.GetByDates(startDate, endDate);

            var resultList = new List<DateDtosDto<ExternalSearchMetricDto>>();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var dateDto = new DateDtosDto<ExternalSearchMetricDto> {Date = date};
                
                var externalSearchesByDate =
                    externalSearches.Where(x => date <= x.CreateDate && x.CreateDate <= date.AddDays(1));

                var durations = externalSearchesByDate.Select(x => x.Duration).Distinct().OrderBy(x => x);

                foreach (var duration in durations)
                {
                    var externalSearchesByDuration = externalSearchesByDate.Where(x => x.Duration == duration);

                    var urls = externalSearchesByDuration.Select(x => x.Url).Distinct();
                    
                    dateDto.Dtos.Add(new ExternalSearchMetricDto
                    {
                        Duration = duration,
                        Items = urls.Select(x => new ExternalSearchItem
                        {
                            Url = x,
                            Count = externalSearchesByDuration.Count(s => s.Url == x)
                        }).ToList() // без метода ToList() item-ы не записываются
                    });
                }
                
                resultList.Add(dateDto);
            }

            return Ok(resultList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}