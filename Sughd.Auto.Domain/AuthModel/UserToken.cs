using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.AuthModel;

public class UserToken : EntityBase
{
    public long UserId { get; set; }
    
    public string Name { get; set; }
}