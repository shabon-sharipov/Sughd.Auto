using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.AuthModel;

public class UserToken : EntityBase
{
    public long UserId { get; set; }
    
    public long Name { get; set; }
}