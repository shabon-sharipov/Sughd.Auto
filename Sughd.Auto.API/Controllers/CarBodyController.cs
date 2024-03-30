using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Domain.Enum;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarBodyController : ControllerBase
{
    public CarBodyController()
    {
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var carBodies = Enum.GetValues(typeof(CarBody));
        return Ok(carBodies);
    }
}