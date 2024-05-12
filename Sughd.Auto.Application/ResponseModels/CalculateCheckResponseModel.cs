namespace Sughd.Auto.Application.ResponseModels;

public class CalculateCheckResponseModel
{
    public string UserPhoneNumber { get; set; }
    public decimal WeeklyDayPrice { get; set; }
    public decimal WeeklyEndPrice { get; set; }
    public int WeeklyDayCount { get; set; }
    public int WeeklyEndCount { get; set; }
    public string DateTime { get; set; }
}