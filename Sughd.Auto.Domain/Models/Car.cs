using Sughd.Auto.Domain.Abstract;
using Sughd.Auto.Domain.Enum;

namespace Sughd.Auto.Domain.Models;

public class Car : EntityBase
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

    public CarBody CarBody { get; set; }
    public long CarBodyId { get; set; }

    public Customer Customer { get; set; }
    public long CustomerId { get; set; }

    public Marka Marka { get; set; }
    public long MarkaId { get; set; }

    public Model Model { get; set; }
    public long ModelId { get; set; }
    
    public Color Color { get; set; }
    public long ColorId { get; set; }
}