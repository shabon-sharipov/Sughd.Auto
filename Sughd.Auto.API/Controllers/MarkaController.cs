using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MarkaController : ControllerBase
{
    private readonly ICarMarkaService _markaService;

    public MarkaController(ICarMarkaService markaService)
    {
        _markaService = markaService;
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _markaService.GetById(id, CancellationToken.None);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromRoute] int pageSize, [FromRoute] int offSet)
    {
        var result = await _markaService.Get(pageSize, offSet, CancellationToken.None);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CarMarkaRequestModel requestModel, CancellationToken cancellationHandler)
    {
        var result = await _markaService.Create(requestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(long id, CarMarkaRequestModel requestModel)
    {
        var result = await _markaService.Update(id, requestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _markaService.Delete(id, CancellationToken.None);
        return Ok(result);
    }
}