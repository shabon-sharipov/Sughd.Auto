using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.AuthModel;

public class UserRole : EntityBase
{
    public long UserId { get; set; }
    public virtual User User { get; set; }
    
    public long RoleId { get; set; }
    public virtual Role Role { get; set; }
}