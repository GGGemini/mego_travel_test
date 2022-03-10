using MegoTravelTest.Helpers;
using MegoTravelTest.Models.Dtos;
using MegoTravelTest.Models.Enums;
namespace MegoTravelTest.Logic.Abstractions;

public abstract class ExternalSearchBase
{
    protected string _url;
    private readonly ILogger _logger;

    protected ExternalSearchBase()
    {
        _logger = LoggerFactory.Create(options => {}).CreateLogger(typeof(ExternalSearchBase));
    }
    
    /// <summary>
    /// Возвращает ответ спустя случайное количество времени в промежутке
    /// </summary>
    /// <param name="url">Куда отправить запрос</param>
    /// <param name="minMs">Минимальное количество миллисекунд</param>
    /// <param name="maxMs">Максимальное количество миллисекунд</param>
    public ExternalSearchDto Request(int minMs, int maxMs)
    {
        var resultDto = new ExternalSearchDto(_url, RandomHelper.GetRandomNumber(minMs, maxMs));
        
        Thread.Sleep(resultDto.Time); // запрос в систему "_url" (задержка)

        resultDto.Result = RandomHelper.GetRandomBool() ? ResultsEnum.OK : ResultsEnum.ERROR; // ошибка или нет

        return resultDto;
    }
}