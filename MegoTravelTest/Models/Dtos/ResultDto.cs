using MegoTravelTest.Models.Enums;

namespace MegoTravelTest.Models.Dtos;

public class ResultDto
{
    public ResultDto()
    {
    }

    public ResultDto(int time)
    {
        this.Time = time;
    }
    
    public ResultsEnum? Result { get; set; }
    
    public int Time { get; set; }
}