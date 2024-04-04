using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;

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

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] Dictionary<string, object> objects)
    {
        var s= await _searchController.Search(objects);
        return Ok(s);
    }
}