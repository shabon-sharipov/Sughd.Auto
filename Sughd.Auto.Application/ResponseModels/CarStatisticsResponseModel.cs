namespace Sughd.Auto.Application.ResponseModels;

public class CarStatisticsResponseModel
{
    public List<StatisticsByDay> ActiveCar { get; set; }
    public List<StatisticsByDay> InActive { get; set; }
    public List<StatisticsByDay> SoldCar { get; set; }
    public double[] TotalCarCount { get; set; }
}

public class StatisticsByDay
{
    public double Count { get; set; }
    public string DaywhisMounth { get; set; }
}