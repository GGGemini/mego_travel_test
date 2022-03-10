namespace MegoTravelTest.Models.Dtos.ExternalSearchMetric;

public class ExternalSearchMetricDto
{
    public int Duration { get; set; }
    
    public IEnumerable<ExternalSearchItem> Items { get; set; }
}