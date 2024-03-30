using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.Models;

public class Marka : EntityBase
{
    public string Name { get; set; }

    public virtual List<Model> Model { get; set; }
}

public class Model : EntityBase
{
    public long MarkaId { get; set; }
    public virtual Marka Marka { get; set; }
    
    public string Name { get; set; }
}