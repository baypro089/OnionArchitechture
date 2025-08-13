using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using Application.DTOs;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<BookDTO>> GetAllBook() {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            var books = await repository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetABook(int id)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            var book = await repository.GetByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDTO bookDTO)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            await repository.AddAsync(bookDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create book");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDTO bookDTO)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            await repository.UpdateAsync(id, bookDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot update book");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            await repository.DeleteAsync(id);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot delete book");
        }
    }
}
