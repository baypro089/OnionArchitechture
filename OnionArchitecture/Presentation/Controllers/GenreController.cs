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
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<GenreDTO>> GetAllGenre()
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            var data = await repository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAGenre(int id)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            var data = await repository.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreDTO genreDTO)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            await repository.AddAsync(genreDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create Genre");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, CreateGenreDTO genreDTO)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            await repository.UpdateAsync(id, genreDTO);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot update Genre");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            await repository.DeleteAsync(id);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) { return Ok("Success"); }
            return BadRequest("Cannot delete genre");
        }
    }
}
