namespace Sughd.Auto.Application.RequestModels.Auth;

public class Login
{
    public string UserEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}