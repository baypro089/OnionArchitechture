using Application.DTOs;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatalogueController : ControllerBase
    {
        public readonly ICatalogueService _catalogueService;

        public CatalogueController(ICatalogueService catalogueService)
        {
            _catalogueService = catalogueService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CatalogueDTO>> GetAllCatalogue()
        {
            var data = await _catalogueService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetACatalogue(int id)
        {
            var data = await _catalogueService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogue(CreateCatalogueDTO bookDTO)
        {
            var response = await _catalogueService.AddAsync(bookDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create Catalogue");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatalogue(int id, CreateCatalogueDTO bookDTO)
        {
            var response = await _catalogueService.UpdateAsync(id, bookDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update CreateCatalogueDTO");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogue(int id)
        {
            var response = await _catalogueService.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete Catalogue");
        }
    }
}
