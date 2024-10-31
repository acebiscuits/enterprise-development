using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.Domain.Dto;

/// <summary>
/// DTO for creating a new album in the media library.
/// </summary>
public class AlbumCreateDto
{
    /// <summary>
    /// The unique identifier of the artist who created the album.
    /// </summary>
    [Required]
    public int ArtistId { get; set; }
    /// <summary>
    /// The title of the album.
    /// </summary>
    [Required]
    public required string Title { get; set; }
    /// <summary>
    /// The release date of the album (year).
    /// </summary>
    [Required]
    public int ReleaseDate { get; set; }
    /// <summary>
    /// The list of song IDs associated with this album.
    /// </summary>
    public List<int> SongIds { get; set; } = [];
}
