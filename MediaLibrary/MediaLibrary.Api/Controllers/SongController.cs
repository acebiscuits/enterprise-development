using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

/// <summary>
/// API Controller for managing songs.
/// Provides CRUD operations for songs.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SongController"/> class.
    /// </summary>
    /// <param name="songService">Service for managing song data.</param>
    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    /// <summary>
    /// Gets all songs.
    /// </summary>
    /// <returns>A list of song DTOs.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<SongDto>> GetAll()
    {
        return Ok(_songService.GetAll());
    }

    /// <summary>
    /// Gets a song by ID.
    /// </summary>
    /// <param name="id">The ID of the song to retrieve.</param>
    /// <returns>The song DTO if found; otherwise, NotFound.</returns>
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

    /// <summary>
    /// Creates a new song.
    /// </summary>
    /// <param name="songCreateDto">The song data to create.</param>
    /// <returns>OK if successful.</returns>
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

    /// <summary>
    /// Updates an existing song.
    /// </summary>
    /// <param name="songDto">The updated song data.</param>
    /// <returns>NoContent if successful.</returns>
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

    /// <summary>
    /// Deletes a song by ID.
    /// </summary>
    /// <param name="id">The ID of the song to delete.</param>
    /// <returns>NoContent if successful; otherwise, NotFound.</returns>
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

    /// <summary>
    /// Gets the ordered list of songs in a specific album.
    /// </summary>
    /// <param name="AlbumTitle">The title of the album to retrieve songs from.</param>
    /// <returns>A list of ordered song DTOs from the specified album, or NotFound if no songs are found.</returns>
    [HttpGet("{AlbumTitle}")]
    public ActionResult GetOrderedSongsInCertainAlbum(string AlbumTitle)
    {
        var songs = _songService.GetOrderedSongsInCertainAlbum(AlbumTitle);
        if (songs == null)
        {
            return NotFound();
        }
        return Ok(songs);
    }
}
