using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.ResponseModels;

public class CarMarkaResponsModel
{
    public ulong Id { get; set; }
    
    public string Name { get; set; }

    public List<Model> Model { get; set; }
}