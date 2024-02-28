using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.Models;

public class Marka : EntityBase
{
    public string Name { get; set; }

    public List<Model> Model { get; set; }
}

public class Model : EntityBase
{
    public string Name { get; set; }
}