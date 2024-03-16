using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _customerService.GetById(id, CancellationToken.None);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromRoute] int pageSize, [FromRoute] int offSet)
    {
        var result = await _customerService.Get(pageSize, offSet, CancellationToken.None);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CustomerRequestModel customerRequestModel)
    {
        var result = await _customerService.Create(customerRequestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(long id, CustomerRequestModel customerRequestModel)
    {
        var result = await _customerService.Update(id,customerRequestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _customerService.Delete(id, CancellationToken.None);
        return Ok(result);
    }
}