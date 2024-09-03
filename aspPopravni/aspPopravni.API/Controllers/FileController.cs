using aspPopravni.API.DTO;
using aspPopravni.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace aspPopravni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] FileUploadDTO dto, [FromServices] popravniContext context)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.File.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.File.CopyTo(fileStream);
            }
            context.Images.Add(new Domain.Entities.Image
            {
                Source = newFileName
            });
            context.SaveChanges();

            return StatusCode(201);
        }
    }
}
