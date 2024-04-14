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
        var cars = await _searchController.Search(searchCarRequestModel);
        return Ok(cars);
    }
    
    [HttpGet("/SearchByUserPhoneNumber")]
    public async Task<IActionResult> SearchByUserName(string phoneNumber)
    {
        var userName = await _searchController.SearchByUserName(phoneNumber);
        return Ok(userName);
    }
    
    [HttpGet("/SearchByMarkaName")]
    public async Task<IActionResult> SearchByMarkaName(string markaName)
    {
        var markaNames = await _searchController.SearchByMarkaName(markaName);
        return Ok(markaNames);
    }
}