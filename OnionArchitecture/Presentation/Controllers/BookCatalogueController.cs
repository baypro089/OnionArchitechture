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
    public class BookCatalogueController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookCatalogueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<BookCatalogueDTO>> GetAllBookCatalogue()
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            var books = await repository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetABookCatalogue(int id)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            var book = await repository.GetByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookCatalogue(CreateBookCatalogueDTO bookDTO)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            await repository.AddAsync(bookDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create BookCatalogue");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookCatalogue(int id, CreateBookCatalogueDTO bookDTO)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            await repository.UpdateAsync(id, bookDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot update BookCatalogue");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCatalogue(int id)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            await repository.DeleteAsync(id);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot delete BookCatalogue");
        }
    }
}

