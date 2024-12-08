using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public readonly IGenericRepository<Genre, GenreDTO, CreateGenreDTO> _repository;

        public GenreController(IGenericRepository<Genre, GenreDTO, CreateGenreDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<GenreDTO>> GetAllGenre()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAGenre(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreDTO genreDTO)
        {
            var response = await _repository.AddAsync(genreDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create Genre");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, CreateGenreDTO genreDTO)
        {
            var response = await _repository.UpdateAsync(id, genreDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update Genre");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var response = await _repository.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete genre");
        }
    }
}
