namespace Sughd.Auto.Application.AuthServices.RequestModels;

public class Login
{
    public string UserEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}