using AutoMapper;
using Sughd.Auto.Application.AuthServices.ResponseModels;
using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Application.AuthServices;

public interface IRoleService
{
    Task<List<RoleResponseModel>> GetRolesAsync();

    Task<List<string>> GetUserRolesAsync(string emailId);

    Task<List<string>> AddRolesAsync(string[] roles);

    Task<bool> AddUserRoleAsync(string userEmail, List<long> roleIds);
}

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository, IMapper mapper, IUserRepository userRepository,
        IUserRoleRepository userRoleRepository)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<List<RoleResponseModel>> GetRolesAsync()
    {
        var roleList = await _roleRepository.GetAllAsync(1000, 0, CancellationToken.None);
        return _mapper.Map<List<RoleResponseModel>>(roleList.ToList());
    }

    public async Task<List<string>> GetUserRolesAsync(string email)
    {
        var user = await _userRepository.FindByEmailAsync(email);

        if (user == null)
        {
            return new List<string>();
        }
        
        return user.Roles.Select(r => r.Name).ToList();
    }

    public async Task<List<string>> AddRolesAsync(string[] roles)
    {
        var rolesList = new List<string>();
        foreach (var role in roles)
        {
            if (await _roleRepository.RoleExistsAsync(role))
            {
                continue;
            }
            
            await _roleRepository.AddAsync(new Role{Name = role});
            rolesList.Add(role);
        }

        await _userRepository.SaveChangesAsync();
        return rolesList;
    }

    public async Task<bool> AddUserRoleAsync(string userEmail, List<long> roleIds)
    {
        var user = await _userRepository.FindByEmailAsync(userEmail);


        if ((user == null || roleIds == null) && !roleIds.Any()) return false;

        foreach (var roleId in roleIds)
        {
            var role = await _roleRepository.FindAsync(roleId);
            user.Roles.Add(role);
            await _userRepository.SaveChangesAsync();
        }

        return true;
    }
}