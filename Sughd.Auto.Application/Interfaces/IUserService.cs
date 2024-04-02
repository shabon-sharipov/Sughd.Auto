using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface IUserService
{
    Task<User?> GetUserById(string userId);
    Task<User?> GetUserByEmail(string email);
    Task<User?> Create(CreateUserRequest createUserRequest);
}