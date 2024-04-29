using Sughd.Auto.API;
using Sughd.Auto.API.Controllers.AuthController;
using Sughd.Auto.API.Middleware;
using Sughd.Auto.Application;
using Sughd.Auto.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddDbContext(builder);
builder.Services.AddAuthToken(builder.Configuration);
builder.Services.AddHostedService<StartupInitializer>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseMiddleware<ApiExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
app.Run();