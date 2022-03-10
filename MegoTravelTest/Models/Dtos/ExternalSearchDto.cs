using MegoTravelTest.Models.Enums;

namespace MegoTravelTest.Models.Dtos;

public class ExternalSearchDto
{
    public ExternalSearchDto()
    {
    }

    public ExternalSearchDto(string url, int time)
    {
        this.Url = url;
        this.Time = time;
    }
    
    public string Url { get; set; }
    
    public ResultsEnum Result { get; set; }
    
    public int Time { get; set; }
}