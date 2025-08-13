using Application.DTOs;
using Domain.Entities;
using Application.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public CatalogueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CatalogueDTO>> GetAllCatalogue()
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            var data = await repository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetACatalogue(int id)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            var data = await repository.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogue(CreateCatalogueDTO bookDTO)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            await repository.AddAsync(bookDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create Catalogue");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatalogue(int id, CreateCatalogueDTO bookDTO)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            await repository.UpdateAsync(id, bookDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot update CreateCatalogueDTO");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogue(int id)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            await repository.DeleteAsync(id);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot delete Catalogue");
        }
    }
}
