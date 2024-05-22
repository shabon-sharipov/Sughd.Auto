using Sughd.Auto.Domain.Abstract;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Domain.Models;

public class Car : EntityBase
{
    public long DateOfPublisher { get; set; }

    public virtual List<string> Images { get; set; }

    public bool IsActive { get; set; }
    
    public string QRCode { get; set; }

    public Guid CalculateCheck { get; set; } = Guid.NewGuid();
    
    public bool IsSold { get; set; }

    public string UserPhoneNumber { get; set; } = string.Empty;
    public virtual Marka Marka { get; set; }
    public long MarkaId { get; set; }

    public virtual Model Model { get; set; }
    public long ModelId { get; set; }
    
    public DateTime PaymentAt { get; set; } = DateTime.UtcNow.AddMinutes(300);
}