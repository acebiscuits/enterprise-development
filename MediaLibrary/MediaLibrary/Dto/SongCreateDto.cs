using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.Domain.Dto;

/// <summary>
/// DTO for creating a new song in the media library.
/// </summary>
public class SongCreateDto
{
    /// <summary>
    /// The name of the song.
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    /// The position of the song in the album.
    /// </summary>
    public int NumberInAlbum { get; set; }

    /// <summary>
    /// The name of the album containing the song.
    /// </summary>
    public string? AlbumName { get; set; }

    /// <summary>
    /// The duration of the song.
    /// </summary>
    public TimeSpan Duration { get; set; }
}
