using Microsoft.AspNetCore.Identity;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.RequestModels.Auth;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface IUserService
{
    Task<User?> GetUserById(string userId);
    Task<User?> GetUserByEmail(string email);
    Task UpdateUserRole(AddOrUpdateUserRoleRequest updateUserRoleRequest);
    Task AddUserRole(string username, string role);
}