namespace Sughd.Auto.Application.RequestModels.Auth;

public class UpdateRoleRequest
{
    public string RoleName { get; set; } = string.Empty;
    public string NewRoleName { get; set; } = string.Empty;
}