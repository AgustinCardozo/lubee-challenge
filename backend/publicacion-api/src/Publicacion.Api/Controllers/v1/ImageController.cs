using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Publicacion.Application.Contracts.UseCases.Images;

namespace Publicacion.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/imagenes")]
    public class ImageController(IImageUseCase _imageUseCase) : ControllerBase
    {
        [HttpGet("{publicationId:int}")]
        public async Task<IActionResult> GetByPublicationIdAsync(int publicationId)
        {
            var images = await _imageUseCase.GetByPublicationIdAsync(publicationId);
            return Ok(images);
        }
    }
}
