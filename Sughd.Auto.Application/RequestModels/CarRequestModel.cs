using Sughd.Auto.Domain.Enum;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.RequestModels;

public class CarRequestModel
{
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

    public ulong CarBodyId { get; set; }

    public ulong CustomerId { get; set; }

    public ulong MarkaId { get; set; }
    
    public ulong ModelId { get; set; }
}