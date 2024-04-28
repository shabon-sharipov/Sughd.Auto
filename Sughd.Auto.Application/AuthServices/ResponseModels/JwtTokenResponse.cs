namespace Sughd.Auto.Application.AuthServices.ResponseModels;

public class JwtTokenResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public List<RoleResponseModel> Roles { get; set; }
}