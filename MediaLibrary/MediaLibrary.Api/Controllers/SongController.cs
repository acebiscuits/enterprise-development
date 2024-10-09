using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SongDto>> GetAll()
    {
        return Ok(_songService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<SongDto> GetById(int id)
    {
        var song = _songService.GetById(id);
        if (song == null)
        {
            return NotFound();
        }
        return Ok(song);
    }

    [HttpPost]
    public ActionResult Add([FromBody] SongCreateDto songCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _songService.Add(songCreateDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update([FromBody] SongDto songDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingSong = _songService.GetById(songDto.Id);
        if (existingSong == null)
        {
            return NotFound();
        }
        _songService.Update(existingSong);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var existingSong = _songService.GetById(id);
        if (existingSong == null)
        {
            return NotFound();
        }
        _songService.Delete(id);
        return NoContent();
    }
}
