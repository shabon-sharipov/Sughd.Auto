using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.AuthModel;

public class UserRole : EntityBase
{
    public long UserId { get; set; }
    
    public long RoleId { get; set; }
}