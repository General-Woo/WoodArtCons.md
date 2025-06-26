using Microsoft.AspNetCore.Mvc;

namespace WoodArtCons.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleFileUploadController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadMultipleFiles(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var filePath = Path.Combine("..", "WoodArtCons", "wwwroot", "Images", "Galery", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { FilePath = filePath });
        }

        [HttpDelete("delete")]
        public IActionResult DeleteMultipleFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return BadRequest("File name is required.");

            var filePath = Path.Combine("..", "WoodArtCons", "wwwroot", "Images", "Galery", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            System.IO.File.Delete(filePath);

            return Ok(new { Message = "File deleted successfully." });
        }
    }
}
