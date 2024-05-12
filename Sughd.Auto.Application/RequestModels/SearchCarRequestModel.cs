namespace Sughd.Auto.Application.RequestModels;

public class SearchCarRequestModel
{
    public long? DateOfPublisherFrom { get; set; }
    public long? DateOfPublisherTo { get; set; }
    public long? MarkaId { get; set; }
    public long? ModelId { get; set; }
}