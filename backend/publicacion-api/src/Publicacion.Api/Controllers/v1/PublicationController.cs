using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Publicacion.Application.Contracts.UseCases;
using Publicacion.Application.DTOs;

namespace Publicacion.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/publicaciones")]
    public class PublicationController(IPublicationUseCase _publicationUseCase) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var publications = await _publicationUseCase.GetGetAllAsync();
            return Ok(publications);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var publication = await _publicationUseCase.GetByIdAsync(id);

            if (publication is null)
            {
                return NotFound();
            }

            return Ok(publication);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PublicationDto publicationDto)
        {
            await _publicationUseCase.AddAsync(publicationDto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, PublicationDto publicationDto)
        {
            await _publicationUseCase.UpdateAsync(id, publicationDto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var exist = await _publicationUseCase.ExistAsync(id);

            if (!exist)
            {
                return NotFound();
            }

            await _publicationUseCase.DeleteAsync(id);
            return Ok();
        }
    }
}
