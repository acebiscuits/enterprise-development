using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository for managing Genre entities.
/// Inherits from the generic Repository class.
/// </summary>
public class RepositoryInMemoryGenre : RepositoryInMemory<Genre>, IRepositoryGenre
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInMemoryGenre"/> class with initial data.
    /// </summary>
    /// <param name="initData">The initial list of genres for the repository.</param>
    public RepositoryInMemoryGenre(List<Genre> initData) : base(initData) { }
    /// <inheritdoc />
    public override void Update(Genre genre)
    {
        var existingGenre = GetById(genre.Id);
        if (existingGenre != null)
        {
            existingGenre.Title = genre.Title;
            existingGenre.ArtistIds = genre.ArtistIds;
        }
    }
}
