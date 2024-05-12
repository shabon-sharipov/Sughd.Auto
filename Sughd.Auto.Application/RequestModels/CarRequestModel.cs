namespace Sughd.Auto.Application.RequestModels;

public class CarRequestModel
{
    public string UserPhoneNumber { get; set; }
    
    public long MarkaId { get; set; }

    public long ModelId { get; set; }
    
    public string DateOfPublisher { get; set; } = string.Empty;
 
    public List<string> Images { get; set; } = new();
}