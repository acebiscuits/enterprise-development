using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArtistController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ArtistDto>> GetAll()
    {
        return Ok(_artistService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ArtistDto> GetById(int id)
    {
        var artist = _artistService.GetById(id);
        if (artist == null)
        {
            return NotFound();
        }
        return Ok(artist);
    }

    [HttpPost]
    public ActionResult Add([FromBody] ArtistCreateDto artistCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _artistService.Add(artistCreateDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update([FromBody] ArtistDto artistDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingArtist = _artistService.GetById(artistDto.Id);

        if(existingArtist == null)
        {
            return NotFound();
        }
        _artistService.Update(artistDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var existingArtist = _artistService.GetById(id);
        if (existingArtist == null)
        {
            return NotFound();
        }
        _artistService.Delete(id);
        return NoContent();
    }
}
