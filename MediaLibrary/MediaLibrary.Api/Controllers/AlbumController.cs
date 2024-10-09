using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AlbumDto>> GetAll()
    {
        return Ok(_albumService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<AlbumDto> Get(int id)
    { 
        var album = _albumService.GetById(id);
        if (album == null)
        {
            return NotFound();
        }
        return Ok(album);
    }

    [HttpPost]
    public ActionResult Add([FromBody] AlbumCreateDto albumCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _albumService.Add(albumCreateDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update([FromBody] AlbumDto albumDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingAlbum = _albumService.GetById(albumDto.Id);

        if (existingAlbum == null)
        {
            return NotFound();
        }
        _albumService.Update(albumDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var existingAlbum = _albumService.GetById(id);
        if(existingAlbum == null)
        {
            return NotFound();
        }
        _albumService.Delete(id);
        return NoContent();
    }
}
