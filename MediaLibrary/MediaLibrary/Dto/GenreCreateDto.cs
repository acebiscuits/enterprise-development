using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.Domain.Dto;

/// <summary>
/// DTO for creating a new genre in the media library.
/// </summary>
public class GenreCreateDto
{
    /// <summary>
    /// The title of the genre.
    /// </summary>
    [Required]
    public required string Title { get; set; }

    /// <summary>
    /// The list of artist IDs associated with this genre.
    /// </summary>
    public List<int> ArtistIds { get; set; } = new();
}
