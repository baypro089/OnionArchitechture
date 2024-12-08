using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatalogueController : ControllerBase
    {
        public readonly IGenericRepository<Catalogue, CatalogueDTO, CreateCatalogueDTO> _repository;

        public CatalogueController(IGenericRepository<Catalogue, CatalogueDTO, CreateCatalogueDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CatalogueDTO>> GetAllCatalogue()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetACatalogue(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogue(CreateCatalogueDTO bookDTO)
        {
            var response = await _repository.AddAsync(bookDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create Catalogue");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatalogue(int id, CreateCatalogueDTO bookDTO)
        {
            var response = await _repository.UpdateAsync(id, bookDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update CreateCatalogueDTO");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogue(int id)
        {
            var response = await _repository.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete Catalogue");
        }
    }
}
