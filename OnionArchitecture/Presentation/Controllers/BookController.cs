using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Entities;
using Application.DTOs;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IGenericRepository<Book, BookDTO, CreateBookDTO> _repository;
        
        public BookController(IGenericRepository<Book, BookDTO, CreateBookDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<BookDTO>> GetAllBook() {
            var books = await _repository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetABook(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTO bookDTO)
        {
            var response = await _repository.AddAsync(bookDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create book");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDTO bookDTO)
        {
            var response = await _repository.UpdateAsync(id, bookDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update book");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _repository.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete book");
        }
    }
}
