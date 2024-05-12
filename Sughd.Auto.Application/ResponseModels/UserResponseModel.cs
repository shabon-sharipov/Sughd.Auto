using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.ResponseModels;

public class UserResponseModel : User
{
    public long Id { get; set; }
    
    public string FulName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public List<Role> Role { get; set; }
}