using Application.DTOs;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Application.Interfaces.Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        public readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<GenreDTO>> GetAllGenre()
        {
            var data = await _genreService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAGenre(int id)
        {
            var data = await _genreService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreDTO genreDTO)
        {
            var response = await _genreService.AddAsync(genreDTO);
            if (response)
            {
                return Ok("Success");
            }
            return BadRequest("Cannot create Genre");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, CreateGenreDTO genreDTO)
        {
            var response = await _genreService.UpdateAsync(id, genreDTO);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot update Genre");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var response = await _genreService.DeleteAsync(id);
            if (response) { return Ok("Success"); }
            return BadRequest("Cannot delete genre");
        }
    }
}
