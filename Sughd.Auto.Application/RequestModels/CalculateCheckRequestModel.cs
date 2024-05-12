namespace Sughd.Auto.Application.RequestModels;

public class CalculateCheckRequestModel
{
    public long CarId { get; set; }
    public decimal WeeklyDayPrice { get; set; }
    public decimal WeeklyEndPrice { get; set; }
}