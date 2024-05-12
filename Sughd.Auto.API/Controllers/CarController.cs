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
    private readonly string _storagePath;

    public CarController(ICarService carService)
    {
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
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

    [HttpGet("GetStatistics")]
    public async Task<IActionResult> GetStatistics()
    {
        var result = await _carService.GetStatistics();
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
    
    [HttpPut("UpdateStatus")]               
    public async Task<IActionResult> UpdateStatus(long id, bool isActive)
    {
        await _carService.UpdateStatus(id, isActive);
        return Ok("Successfully updated");
    }
    
    [HttpPut("UpdateImage")]
    public async Task<IActionResult> UpdateImage(long id, List<IFormFile> ? images)
    {
        var listUrl = new List<string>();

        if (images == null) return BadRequest();
        
        foreach (var image in images)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded");
            }

            var filename = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(_storagePath, filename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Return the URL to access the image
            var imageUrl = $"{Request.Scheme}://{Request.Host}/images/{filename}";
            listUrl.Add(imageUrl);
        }
        
        await _carService.UpdateImage(id, listUrl);
        return Ok(listUrl.Count);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _carService.Delete(id, CancellationToken.None);
        return Ok(result);
    }
}