using MegoTravelTest.Helpers;
using MegoTravelTest.Models.Dtos;
using MegoTravelTest.Models.Enums;

namespace MegoTravelTest.Logic.Abstractions;

public abstract class ExternalSearch
{
    protected string _url;
    
    /// <summary>
    /// Возвращает ответ спустя случайное количество времени в промежутке
    /// </summary>
    /// <param name="url">Куда отправить запрос</param>
    /// <param name="minMs">Минимальное количество миллисекунд</param>
    /// <param name="maxMs">Максимальное количество миллисекунд</param>
    public ResultDto Request(int minMs, int maxMs)
    {
        var resultDto = new ResultDto(RandomHelper.GetRandomNumber(minMs, maxMs));
        
        Thread.Sleep(resultDto.Time); // запрос в систему "_url" (задержка)

        resultDto.Result = RandomHelper.GetRandomBool() ? ResultsEnum.OK : ResultsEnum.ERROR; // ошибка или нет

        return resultDto;
    }
}