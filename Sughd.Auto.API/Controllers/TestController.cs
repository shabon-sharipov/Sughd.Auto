using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private ITestRepository _testRepository;
    
    public TestController(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }

    [HttpPost]
    public async Task Post(Test test)
    {
        await _testRepository.AddAsync(test);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string test)
    {
        return Ok(await _testRepository.SearchByUserName(test));
    }
}