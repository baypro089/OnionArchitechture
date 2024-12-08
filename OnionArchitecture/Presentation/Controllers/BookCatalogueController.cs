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
    public class BookCatalogueController : ControllerBase
    {
        public readonly IGenericRepository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO> _repository;

        public BookCatalogueController(IGenericRepository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<BookCatalogueDTO>> GetAllBookCatalogue()
        {
            var books = await _repository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetABookCatalogue(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookCatalogue(CreateBookCatalogueDTO bookDTO)
        {
            var response = await _repository.AddAsync(bookDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create BookCatalogue");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookCatalogue(int id, CreateBookCatalogueDTO bookDTO)
        {
            var response = await _repository.UpdateAsync(id, bookDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update BookCatalogue");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCatalogue(int id)
        {
            var response = await _repository.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete BookCatalogue");
        }
    }
}

