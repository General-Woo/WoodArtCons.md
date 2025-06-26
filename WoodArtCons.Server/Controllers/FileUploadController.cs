using Microsoft.AspNetCore.Mvc;

namespace WoodArtCons.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var filePath = Path.Combine("..", "WoodArtCons", "wwwroot", "Images", "Categories", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { FilePath = filePath });
        }

        [HttpDelete("delete")]
        public IActionResult DeleteFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return BadRequest("File name is required.");

            var filePath = Path.Combine("..", "WoodArtCons", "wwwroot", "Images", "Categories", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            System.IO.File.Delete(filePath);

            return Ok(new { Message = "File deleted successfully." });
        }
    }
}
