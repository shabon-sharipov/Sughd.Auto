using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ModelController : ControllerBase
{
    private readonly ICarModelService _carModelService;

    public ModelController(ICarModelService carModelService)
    {
        _carModelService = carModelService;
    }

    [AllowAnonymous]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _carModelService.GetById(id, CancellationToken.None);
        return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpGet("GetByMarkaId")]
    public async Task<IActionResult> GetByMarkaId(long markaId)
    {
        var result = await _carModelService.GetByMarkaId(markaId);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] int pageSize, [FromQuery] int offSet)
    {
        var result = await _carModelService.Get(pageSize, offSet, CancellationToken.None);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CarModelRequestModel requestModel, CancellationToken cancellationHandler)
    {
        var result = await _carModelService.Create(requestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(long id, CarModelRequestModel requestModel)
    {
        var result = await _carModelService.Update(id, requestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _carModelService.Delete(id, CancellationToken.None);
        return Ok(result);
    }
}