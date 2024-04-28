using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Constants;
using Sughd.Auto.Application.Exceptions;
using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.API.Controllers.AuthController;

public class StartupInitializer : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public StartupInitializer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            var roleRepository = scope.ServiceProvider.GetRequiredService<IRoleRepository>();

            // Initialization logic
            if (!await roleRepository.RoleExistsAsync(UserRoles.Admin))
                await roleRepository.AddAsync(new Role() { Name = UserRoles.Admin }, cancellationToken);

            if (!await roleRepository.RoleExistsAsync(UserRoles.Moderator))
                await roleRepository.AddAsync(new Role() { Name = UserRoles.Moderator }, cancellationToken);

            var userExists = await userRepository.FindByNameAsync("Admin");

            if (userExists == null)
            {
                var user = new User()
                {
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    Password = "Admin.1234",
                    PhoneNumber = "",
                    RefreshToken = Guid.NewGuid().ToString()
                };

                var adminRole = await roleRepository.GetByName(UserRoles.Admin);
                if (adminRole == null)
                {
                    throw new EntityNotFoundException("Not found role: Admin");
                }

                user.Roles.Add(adminRole);

                var moderatorRole = await roleRepository.GetByName(UserRoles.Moderator);
                if (moderatorRole == null)
                {
                    throw new EntityNotFoundException("Not found role: Moderator");
                }

                user.Roles.Add(moderatorRole);
                await userRepository.AddAsync(user, cancellationToken);
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}