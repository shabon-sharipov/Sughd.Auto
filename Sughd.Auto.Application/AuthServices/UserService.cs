using AutoMapper;
using Sughd.Auto.Application.AuthServices.ResponseModels;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.AuthServices.RequestModels;
using Sughd.Auto.Application.Exceptions;
using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.Application.AuthServices;

public interface IUserService
{
    Task<UserResponseModel> GetById(long id, CancellationToken cancellationToken);

    Task<UserResponseModel> Update(long id, UserUpdateRequestModel entity, CancellationToken cancellationToken);
    Task<List<UserResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<UserResponseModel> Delete(long id, CancellationToken cancellationToken);
    Task<double[]> GetStatistics();
    Task<UserResponseModel> FindByNameAsync(string email, CancellationToken cancellationToken);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<UserResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        var car = await _userRepository.FindAsync(id, cancellationToken);

        return _mapper.Map<UserResponseModel>(car);
    }

    public async Task<UserResponseModel> Update(long id, UserUpdateRequestModel entity,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(id, cancellationToken);

        user.UserName = entity.UserName;
        user.PhoneNumber = entity.PhoneNumber;
        user.Password = entity.Password;
        user.RefreshToken = entity.RefreshToken;
        user.Roles.Clear();

        foreach (var roleId in entity.RoleIds)
        {
            var role = await _roleRepository.FindAsync(roleId);
            user.Roles.Add(role);
        }

        await _userRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserResponseModel>(user);
    }

    public async Task<List<UserResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);

        var userResponse = new List<UserResponseModel>();

        foreach (var user in users.ToList())
        {
            userResponse.Add(new UserResponseModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                RefreshToken = user.RefreshToken,
                Roles = _mapper.Map<List<RoleResponseModel>>(user.Roles),
                Password = user.Password
            });
        }

        return userResponse;
    }

    public async Task<UserResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(id, cancellationToken);
        if (user == null)
        {
            throw new EntityNotFoundException($"Not found user by ID: {id}");
        }

        _userRepository.Delete(user);
        await _userRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UserResponseModel>(user);
    }

    public Task<double[]> GetStatistics()
    {
        return _userRepository.GetStatistics();
    }

    public async Task<UserResponseModel> FindByNameAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmailAsync(email);

        if (user == null)
        {
            throw new EntityNotFoundException($"Not found user by Email: {email}");
        }

        return _mapper.Map<UserResponseModel>(user);
    }
}