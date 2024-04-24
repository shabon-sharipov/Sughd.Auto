namespace Sughd.Auto.Application.AuthServices.RequestModels;

public class AddUserRoleRequestModel
{
    public string UserEmail { get; set; }
    public List<long> RoleIds { get; set; }
}