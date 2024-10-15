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
    public ActionResult<IEnumerable<AlbumDto>> GetAll()
    {
        return Ok(_albumService.GetAll());
    }

    /// <summary>
    /// Gets an album by ID.
    /// </summary>
    /// <param name="id">The ID of the album to retrieve.</param>
    /// <returns>The album DTO if found; otherwise, NotFound.</returns>
    [HttpGet("{id:int}")]
    public ActionResult<AlbumDto> GetById(int id)
    {
        var album = _albumService.GetById(id);
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
    public ActionResult Add([FromBody] AlbumCreateDto albumCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _albumService.Add(albumCreateDto);
        return Ok();
    }

    /// <summary>
    /// Updates an existing album.
    /// </summary>
    /// <param name="albumDto">The updated album data.</param>
    /// <returns>NoContent if successful.</returns>
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

    /// <summary>
    /// Deletes an album by ID.
    /// </summary>
    /// <param name="id">The ID of the album to delete.</param>
    /// <returns>NoContent if successful; otherwise, NotFound.</returns>
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var existingAlbum = _albumService.GetById(id);
        if (existingAlbum == null)
        {
            return NotFound();
        }
        _albumService.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Gets albums released in a specified year, including additional info such as album duration.
    /// </summary>
    /// <param name="year">The year of the album release.</param>
    /// <returns>A list of albums with additional information for the specified year, or NotFound if no albums are found.</returns>
    [HttpGet("year/{year:int}")]
    public ActionResult<IEnumerable<AlbumInfoAndDurationDto>> GetInfoAboutAlbumsInCertainYear(int year)
    {
        var albumsInfo = _albumService.GetInfoAboutAlbumsInCertainYear(year);
        return Ok(albumsInfo);
    }

    /// <summary>
    /// Gets the top five albums with the longest total duration.
    /// </summary>
    /// <returns>A list of the top five albums by duration, or NotFound if no albums are found.</returns>
    [HttpGet("top-five-by-duration")]
    public ActionResult<IEnumerable<AlbumDto>> GetTopFiveAlbumsByDuration()
    {
        var albums = _albumService.GetTopFiveAlbumsByDuration();
        return Ok(albums);
    }

    /// <summary>
    /// Gets the minimum, average, and maximum album durations.
    /// </summary>
    /// <returns>A DTO with min, avg, and max album durations, or NotFound if no data is available.</returns>
    [HttpGet("min-avg-max-duration")]
    public ActionResult<IEnumerable<MinAvgMaxDurationDto>> GetMinAvgMaxAlbumsDuration()
    {
        var durations = _albumService.GetMinAvgMaxAlbumsDuration();
        return Ok(durations);
    }
}
