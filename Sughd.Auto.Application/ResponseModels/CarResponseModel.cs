using Sughd.Auto.Domain.Enum;

namespace Sughd.Auto.Application.ResponseModels;

public class CarResponseModel
{
    //TODO need delete unnecessary property
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string VINCode { get; set; }

    public string DateOfPablisher { get; set; }

    public decimal Price { get; set; }

    public string EngineCapacity { get; set; }

    public decimal Mileage { get; set; }

    public double IsRastamogeno { get; set; }

    public List<string> Images { get; set; }

    public bool IsActive { get; set; }

    public FuelType FuelType { get; set; }

    public Transmission Transmission { get; set; }

    public long CarBodyId { get; set; }

    public long CustomerId { get; set; }

    public long MarkaId { get; set; }
    
    public long ModelId { get; set; }
}