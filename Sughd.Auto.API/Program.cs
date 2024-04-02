using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application;
using Sughd.Auto.Application.Services.Auth;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure;
using Sughd.Auto.Infrastructure.DataBase;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();

builder.Services.AddDbContext<EFContext>(options =>
{
    builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseLazyLoadingProxies();
});

var jwtSettings =builder.Configuration.GetSection("JwtSettings").Get<TokenService.JwtSettings>();
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<EFContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
