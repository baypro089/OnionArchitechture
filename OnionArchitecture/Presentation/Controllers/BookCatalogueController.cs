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
    public class BookCatalogueController : ControllerBase
    {
        public readonly IBookCatalogueService _bookCatalogueService;

        public BookCatalogueController(IBookCatalogueService bookCatalogueService)
        {
            _bookCatalogueService = bookCatalogueService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<BookCatalogueDTO>> GetAllBookCatalogue()
        {
            var books = await _bookCatalogueService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetABookCatalogue(int id)
        {
            var book = await _bookCatalogueService.GetByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookCatalogue(CreateBookCatalogueDTO bookDTO)
        {
            var response = await _bookCatalogueService.AddAsync(bookDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create BookCatalogue");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookCatalogue(int id, CreateBookCatalogueDTO bookDTO)
        {
            var response = await _bookCatalogueService.UpdateAsync(id, bookDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update BookCatalogue");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCatalogue(int id)
        {
            var response = await _bookCatalogueService.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete BookCatalogue");
        }
    }
}

