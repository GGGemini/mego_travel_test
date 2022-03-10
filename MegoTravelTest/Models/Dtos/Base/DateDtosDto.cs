namespace MegoTravelTest.Models.Dtos.Base;

public class DateDtosDto<T>
{
    public DateDtosDto()
    {
        this.Dtos = new List<T>();
    }

    public DateTime Date { get; set; }

    public List<T> Dtos { get; set; }
}