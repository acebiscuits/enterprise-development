﻿using MediaLibrary.Domain.Dto;
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
    public async Task<ActionResult<IEnumerable<SongDto>>> GetAll()
    {
        var songs = await _songService.GetAll();
        return Ok(songs);
    }

    /// <summary>
    /// Gets a song by ID.
    /// </summary>
    /// <param name="id">The ID of the song to retrieve.</param>
    /// <returns>The song DTO if found; otherwise, NotFound.</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SongDto>> GetById(int id)
    {
        var song = await _songService.GetById(id);
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
    public async Task<ActionResult> Add([FromBody] SongCreateDto songCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _songService.Add(songCreateDto);
        return Ok();
    }

    /// <summary>
    /// Updates an existing song.
    /// </summary>
    /// <param name="songDto">The updated song data.</param>
    /// <returns>NoContent if successful.</returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] SongDto songDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingSong = await _songService.GetById(songDto.Id);
        if (existingSong == null)
        {
            return NotFound();
        }
        await _songService.Update(songDto);
        return Ok();
    }

    /// <summary>
    /// Deletes a song by ID.
    /// </summary>
    /// <param name="id">The ID of the song to delete.</param>
    /// <returns>NoContent if successful; otherwise, NotFound.</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingSong = await _songService.GetById(id);
        if (existingSong == null)
        {
            return NotFound();
        }
        await _songService.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Gets the ordered list of songs in a specific album.
    /// </summary>
    /// <param name="albumTitle">The title of the album to retrieve songs from.</param>
    /// <returns>A list of ordered song DTOs from the specified album, or NotFound if no songs are found.</returns>
    [HttpGet("{albumTitle}")]
    public async Task<ActionResult<IEnumerable<SongDto>>> GetOrderedSongsInCertainAlbum(string albumTitle)
    {
        var songs = await _songService.GetOrderedSongsInCertainAlbum(albumTitle);
        return Ok(songs);
    }
}
