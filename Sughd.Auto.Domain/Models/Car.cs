using Sughd.Auto.Domain.Abstract;
using Sughd.Auto.Domain.Enum;

namespace Sughd.Auto.Domain.Models;

public class Car : EntityBase
{
    public string VINCode { get; set; } = string.Empty;

    public string DateOfPablisher { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal EngineCapacity { get; set; }

    public decimal Mileage { get; set; }

    public double IsRastamogeno { get; set; }

    public List<string> Images { get; set; }

    public bool IsActive { get; set; }

    public FuelType FuelType { get; set; }

    public Transmission Transmission { get; set; }

    public CarBody CarBody { get; set; }

    public virtual Marka Marka { get; set; }
    public long MarkaId { get; set; }

    public virtual Model Model { get; set; }
    public long ModelId { get; set; }

    public string Color { get; set; } = string.Empty;
}