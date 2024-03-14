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
    public async Task<IActionResult> GetById(ulong id)
    {
        return Ok("ueiwlcjbsa");
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromRoute] int pageSize, [FromRoute] int offSet)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CustomerRequestModel customerRequestModel)
    {
        var result = await _customerService.Create(customerRequestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(ulong id, CustomerRequestModel customerRequestModel)
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ulong id)
    {
        return Ok();
    }
}