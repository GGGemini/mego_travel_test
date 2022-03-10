using System.ComponentModel.DataAnnotations.Schema;
using MegoTravelTest.Models.Dtos;
using MegoTravelTest.Models.Enums;

namespace MegoTravelTest.Models.Entities;

public class ExternalSearch
{
    public ExternalSearch()
    {
    }

    public ExternalSearch(ExternalSearchDto dto)
    {
        this.CreateDate = DateTime.Now;
        this.Url = dto.Url;
        this.Result = dto.Result;
        this.Duration = dto.Time / 1000;
    }
    
    public int Id { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public string Url { get; set; }
    
    public ResultsEnum Result { get; set; }
    
    public int Duration { get; set; }
}