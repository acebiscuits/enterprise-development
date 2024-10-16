using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Api.Controllers;

/// <summary>
/// API Controller for managing artists.
/// Provides CRUD operations for artists.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ArtistController : ControllerBase
{
    private readonly IArtistService _artistService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtistController"/> class.
    /// </summary>
    /// <param name="artistService">Service for managing artist data.</param>
    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    /// <summary>
    /// Gets all artists.
    /// </summary>
    /// <returns>A list of artist DTOs.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ArtistDto>> GetAll()
    {
        return Ok(_artistService.GetAll());
    }

    /// <summary>
    /// Gets an artist by ID.
    /// </summary>
    /// <param name="id">The ID of the artist to retrieve.</param>
    /// <returns>The artist DTO if found; otherwise, NotFound.</returns>
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

    /// <summary>
    /// Creates a new artist.
    /// </summary>
    /// <param name="artistCreateDto">The artist data to create.</param>
    /// <returns>OK if successful.</returns>
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

    /// <summary>
    /// Updates an existing artist.
    /// </summary>
    /// <param name="artistDto">The updated artist data.</param>
    /// <returns>NoContent if successful.</returns>
    [HttpPut]
    public ActionResult Update([FromBody] ArtistDto artistDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingArtist = _artistService.GetById(artistDto.Id);

        if (existingArtist == null)
        {
            return NotFound();
        }
        _artistService.Update(artistDto);
        return NoContent();
    }

    /// <summary>
    /// Deletes an artist by ID.
    /// </summary>
    /// <param name="id">The ID of the artist to delete.</param>
    /// <returns>NoContent if successful; otherwise, NotFound.</returns>
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

    /// <summary>
    /// Gets the artists with the maximum number of albums.
    /// </summary>
    /// <returns>A list of artist DTOs with the maximum number of albums, or NotFound if no artists are found.</returns>
    [HttpGet("max-album-count")]
    public ActionResult<IEnumerable<ArtistDto>> GetMaxAlbumsCountArtists()
    {
        var artists = _artistService.GetMaxAlbumsCountArtists();
        return Ok(artists);
    }
}
