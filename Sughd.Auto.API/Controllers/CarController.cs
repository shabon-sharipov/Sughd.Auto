using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(ulong id)
    {
        var s = await _carService.GetById(id, CancellationToken.None);
        return Ok("ueiwlcjbsa");
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromRoute] int pageSize, [FromRoute] int offSet)
    {
        //EFContext s = new EFContext(new DbContextOptions<EFContext>());
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CarRequestModel carRequestModel)
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(ulong id, CarRequestModel carRequestModel)
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ulong id)
    {
        return Ok();
    }
}