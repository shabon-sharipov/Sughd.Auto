namespace Sughd.Auto.Application.RequestModels;

public class CalculateCheckRequestModel
{
    public Guid CarId { get; set; }
    public decimal WeeklyDayPrice { get; set; }
    public decimal WeeklyEndPrice { get; set; }
}