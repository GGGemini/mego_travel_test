using MegoTravelTest.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegoTravelTest.Models.Dtos;

public class ResultDto
{
    public ResultDto()
    {
    }

    public ResultDto(string url, int time)
    {
        this.Url = url;
        this.Time = time;
    }
    
    public string Url { get; set; }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public ResultsEnum? Result { get; set; }
    
    public int Time { get; set; }
}