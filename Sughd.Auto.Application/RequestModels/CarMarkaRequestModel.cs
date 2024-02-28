using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.RequestModels;

public class CarMarkaRequestModel
{
    public string Name { get; set; }

    public List<Model> Model { get; set; }
}