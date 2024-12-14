using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using Application.DTOs;
using Application.Interfaces.Services;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        public readonly IBookService _bookService;
        
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<BookDTO>> GetAllBook() {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetABook(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTO bookDTO)
        {
            var response = await _bookService.AddAsync(bookDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create book");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDTO bookDTO)
        {
            var response = await _bookService.UpdateAsync(id, bookDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update book");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete book");
        }
    }
}
