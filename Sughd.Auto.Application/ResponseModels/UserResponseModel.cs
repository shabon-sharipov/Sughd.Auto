using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.ResponseModels;

public class UserResponseModel : User
{
    public List<CarResponseModel> Cars { get; set; } = new();
    public List<string> Roles { get; set; } = new();
}
