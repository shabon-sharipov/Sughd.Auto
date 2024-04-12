namespace Sughd.Auto.Application.RequestModels;

public class SearchCarRequestModel
{
    public string? DateOfPablisher { get; set; } = string.Empty;

    public decimal? PriceTo { get; set; }
    
    public decimal? PriceFrom { get; set; }

    public decimal? EngineCapacity { get; set; }

    public double? IsRastamogeno { get; set; }

    public string? FuelType { get; set; } = string.Empty;

    public string? Transmission { get; set; } = string.Empty;

    public string? CarBody { get; set; } = string.Empty;
    
    public long? MarkaId { get; set; }

    public long? ModelId { get; set; }

    public string? Color { get; set; } = string.Empty;
}