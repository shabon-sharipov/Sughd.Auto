using Microsoft.AspNetCore.Mvc;

namespace Sughd.Auto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private readonly string _storagePath;

    public ImageController()
    {
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(List<IFormFile> ? images)
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

        return Ok(listUrl);
    }
}