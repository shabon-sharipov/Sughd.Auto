using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    public ISearchService _searchController;

    public SearchController(ISearchService searchController)
    {
        _searchController = searchController;
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchCarRequestModel searchCarRequestModel)
    {
        var s = await _searchController.Search(searchCarRequestModel);
        return Ok(s);
    }
    
    [HttpGet("/SearchByUserName")]
    public async Task<IActionResult> SearchByUserName(string name)
    {
        var s = await _searchController.SearchByUserName(name);
        return Ok(s);
    }
}