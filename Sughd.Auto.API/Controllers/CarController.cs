using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [AllowAnonymous]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _carService.GetById(id, CancellationToken.None);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] int pageSize, [FromQuery] int offSet)
    {
        var result = await _carService.Get(pageSize, offSet, CancellationToken.None);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]CarRequestModel carRequestModel)
    {
        var result = await _carService.Create(carRequestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpPut]               
    public async Task<IActionResult> Update(long id, CarRequestModel carRequestModel)
    {
        var result = await _carService.Update(id, carRequestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _carService.Delete(id, CancellationToken.None);
        return Ok(result);
    }
}