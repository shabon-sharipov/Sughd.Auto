using Sughd.Auto.Domain.Enum;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.ResponseModels;

public class CarResponseModel
{
    public long Id { get; set; }

    public string DateOfPublisher { get; set; } = string.Empty;

    public List<string> Images { get; set; }
    
    public string QRCode { get; set; }
  
    public string UserPhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public string MarkaName { get; set; } = string.Empty;
    public long MarkaId { get; set; }

    public string ModelName { get; set; } = string.Empty;
    public long ModelId { get; set; }
}