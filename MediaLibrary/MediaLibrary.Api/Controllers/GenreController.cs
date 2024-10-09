using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<GenreDto>> GetAll()
    {
        return Ok(_genreService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<GenreDto> GetById(int id)
    {
        var genre = _genreService.GetById(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public ActionResult Add([FromBody]GenreCreateDto genreCreateDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _genreService.Add(genreCreateDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update([FromBody] GenreDto genreDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var exisctingGenre = _genreService.GetById(genreDto.Id);
        if (exisctingGenre == null)
        {
            return NotFound();
        }

        _genreService.Update(genreDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var existingGenre = _genreService.GetById(id);
        if (existingGenre == null)
        {
            return NotFound();
        }
        _genreService.Delete(id);
        return NoContent();
    }
}
