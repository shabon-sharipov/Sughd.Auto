﻿using Sughd.Auto.Application.AuthServices.ResponseModels;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Application.RequestModels;

public class UserUpdateRequestModel
{
    public string UserName { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

    public string RefreshToken { get; set; }

    public List<long> RoleIds { get; set; }
}