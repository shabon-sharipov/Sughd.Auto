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

    public virtual List<string> Images { get; set; }

    public bool IsActive { get; set; }
    
    public string CarNumber { get; set; } = string.Empty;

    public string FuelType { get; set; } = string.Empty;

    public string Transmission { get; set; } = string.Empty;

    public string CarBody { get; set; } = string.Empty;

    public virtual User User { get; set; }
    public int UserId { get; set; }
    
    public virtual Marka Marka { get; set; }
    public long MarkaId { get; set; }

    public virtual Model Model { get; set; }
    public long ModelId { get; set; }

    public string Color { get; set; } = string.Empty;
}