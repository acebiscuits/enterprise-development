using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.Domain.Dto;

/// <summary>
/// DTO for transferring genre data between layers in the media library.
/// </summary>
public class GenreDto
{
    /// <summary>
    /// The unique identifier of the genre.
    /// </summary>
    [Required]
    public required int Id { get; set; }

    /// <summary>
    /// The title of the genre.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The list of artist IDs associated with this genre.
    /// </summary>
    public List<int> ArtistIds { get; set; } = new();
}
