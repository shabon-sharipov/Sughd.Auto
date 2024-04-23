using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.AuthModel;

public class Role : EntityBase
{
    public string Name { get; set; }
    
    public List<User> Users { get; set; }
}