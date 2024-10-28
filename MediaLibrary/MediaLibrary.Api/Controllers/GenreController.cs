using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

/// <summary>
/// API Controller for managing genres.
/// Provides CRUD operations for genres.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenreController"/> class.
    /// </summary>
    /// <param name="genreService">Service for managing genre data.</param>
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    /// <summary>
    /// Gets all genres.
    /// </summary>
    /// <returns>A list of genre DTOs.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreDto>>> GetAll()
    {
        var genres = await _genreService.GetAll();
        return Ok(genres);
    }

    /// <summary>
    /// Gets a genre by ID.
    /// </summary>
    /// <param name="id">The ID of the genre to retrieve.</param>
    /// <returns>The genre DTO if found; otherwise, NotFound.</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GenreDto>> GetById(int id)
    {
        var genre = await _genreService.GetById(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    /// <summary>
    /// Creates a new genre.
    /// </summary>
    /// <param name="genreCreateDto">The genre data to create.</param>
    /// <returns>OK if successful.</returns>
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] GenreCreateDto genreCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _genreService.Add(genreCreateDto);
        return Ok();
    }

    /// <summary>
    /// Updates an existing genre.
    /// </summary>
    /// <param name="genreDto">The updated genre data.</param>
    /// <returns>NoContent if successful.</returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] GenreDto genreDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingGenre = await _genreService.GetById(genreDto.Id);
        if (existingGenre == null)
        {
            return NotFound();
        }

        await _genreService.Update(genreDto);
        return NoContent();
    }

    /// <summary>
    /// Deletes a genre by ID.
    /// </summary>
    /// <param name="id">The ID of the genre to delete.</param>
    /// <returns>NoContent if successful; otherwise, NotFound.</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingGenre = await _genreService.GetById(id);
        if (existingGenre == null)
        {
            return NotFound();
        }
        await _genreService.Delete(id);
        return NoContent();
    }
}
