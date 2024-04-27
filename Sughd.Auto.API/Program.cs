using Microsoft.EntityFrameworkCore;
using Sughd.Auto.API;
using Sughd.Auto.Application;
using Sughd.Auto.Infrastructure;
using Sughd.Auto.Infrastructure.DataBase;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddDbContext(builder);
builder.Services.AddAuthToken(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorization();
    
app.MapControllers();

app.Run();  
