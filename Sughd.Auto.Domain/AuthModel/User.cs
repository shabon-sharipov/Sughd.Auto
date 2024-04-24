using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Domain.AuthModel;

public class User : EntityBase
{
    public string UserName { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

    public string RefreshToken { get; set; }

    public virtual List<Role> Roles { get; set; } = [];
}