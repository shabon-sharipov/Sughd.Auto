using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FavoriteUserCarController : ControllerBase
{
    private readonly IFavoriteUserCarService _favoriteUserCarService;
    
    public FavoriteUserCarController(IFavoriteUserCarService favoriteUserCarService)
    {
        _favoriteUserCarService = favoriteUserCarService;
    }
    
    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetById([FromQuery]long userId)
    {
        var result = await _favoriteUserCarService.GetByUserId(userId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FavoriteUserCarRequestModel favoriteUserCarRequestModel)
    {
        try
        {
            await _favoriteUserCarService.Add(favoriteUserCarRequestModel.UserId, favoriteUserCarRequestModel.CarId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery]long userId, [FromQuery]long carId)
    {
        try
        {
            await _favoriteUserCarService.Delete(userId, carId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}