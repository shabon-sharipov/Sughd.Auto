namespace Sughd.Auto.Application.AuthServices.RequestModels;

public class LoginRequestModel
{
    public string UserEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}