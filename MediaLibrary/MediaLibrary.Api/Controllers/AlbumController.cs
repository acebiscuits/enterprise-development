using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

/// <summary>
/// API Controller for managing albums.
/// Provides CRUD operations for albums.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AlbumController"/> class.
    /// </summary>
    /// <param name="albumService">Service for managing album data.</param>
    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    /// <summary>
    /// Gets all albums.
    /// </summary>
    /// <returns>A list of album DTOs.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAll()
    {
        var albums = await _albumService.GetAll();
        return Ok(albums);
    }

    /// <summary>
    /// Gets an album by ID.
    /// </summary>
    /// <param name="id">The ID of the album to retrieve.</param>
    /// <returns>The album DTO if found; otherwise, NotFound.</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AlbumDto>> GetById(int id)
    {
        var album = await _albumService.GetById(id);
        if (album == null)
        {
            return NotFound();
        }
        return Ok(album);
    }

    /// <summary>
    /// Creates a new album.
    /// </summary>
    /// <param name="albumCreateDto">The album data to create.</param>
    /// <returns>OK if successful.</returns>
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AlbumCreateDto albumCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _albumService.Add(albumCreateDto);
        return Ok();
    }

    /// <summary>
    /// Updates an existing album.
    /// </summary>
    /// <param name="albumDto">The updated album data.</param>
    /// <returns>NoContent if successful.</returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] AlbumDto albumDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingAlbum = await _albumService.GetById(albumDto.Id);

        if (existingAlbum == null)
        {
            return NotFound();
        }
        await _albumService.Update(albumDto);
        return NoContent();
    }

    /// <summary>
    /// Deletes an album by ID.
    /// </summary>
    /// <param name="id">The ID of the album to delete.</param>
    /// <returns>NoContent if successful; otherwise, NotFound.</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingAlbum = await _albumService.GetById(id);
        if (existingAlbum == null)
        {
            return NotFound();
        }
        await _albumService.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Gets albums released in a specified year, including additional info such as album duration.
    /// </summary>
    /// <param name="year">The year of the album release.</param>
    /// <returns>A list of albums with additional information for the specified year, or NotFound if no albums are found.</returns>
    [HttpGet("year/{year:int}")]
    public async Task<ActionResult<IEnumerable<AlbumInfoAndDurationDto>>> GetInfoAboutAlbumsInCertainYear(int year)
    {
        var albumsInfo = await _albumService.GetInfoAboutAlbumsInCertainYear(year);
        return Ok(albumsInfo);
    }

    /// <summary>
    /// Gets the top five albums with the longest total duration.
    /// </summary>
    /// <returns>A list of the top five albums by duration, or NotFound if no albums are found.</returns>
    [HttpGet("top-five-by-duration")]
    public async Task<ActionResult<IEnumerable<AlbumDto>>> GetTopFiveAlbumsByDuration()
    {
        var albums = await _albumService.GetTopFiveAlbumsByDuration();
        return Ok(albums);
    }

    /// <summary>
    /// Gets the minimum, average, and maximum album durations.
    /// </summary>
    /// <returns>A DTO with min, avg, and max album durations, or NotFound if no data is available.</returns>
    [HttpGet("min-avg-max-duration")]
    public async Task<ActionResult<IEnumerable<MinAvgMaxDurationDto>>> GetMinAvgMaxAlbumsDuration()
    {
        var durations = await _albumService.GetMinAvgMaxAlbumsDuration();
        return Ok(durations);
    }
}
