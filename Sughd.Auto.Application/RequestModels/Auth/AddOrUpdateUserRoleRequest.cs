using System.ComponentModel.DataAnnotations;

namespace Sughd.Auto.Application.RequestModels.Auth;

public class AddOrUpdateUserRoleRequest
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string UserEmail { get; set; }

    public string NewRole { get; set; } = string.Empty;
    
    public string OldRole { get; set; } = string.Empty;
}