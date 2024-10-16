using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository for managing Album entities.
/// Inherits from the generic Repository class.
/// </summary>
public class RepositoryInMemoryAlbum : RepositoryInMemory<Album>, IRepositoryAlbum
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInMemoryAlbum"/> class with initial data.
    /// </summary>
    /// <param name="initData">The initial list of albums for the repository.</param>
    public RepositoryInMemoryAlbum(List<Album> initData) : base(initData) { }
    /// <inheritdoc />
    public override void Update(Album album)
    {
        var existingAlbum = GetById(album.Id);
        if (existingAlbum != null)
        {
            existingAlbum.ArtistId = album.ArtistId;
            existingAlbum.SongIds = album.SongIds;
            existingAlbum.ReleaseDate = album.ReleaseDate;
            existingAlbum.Title = album.Title;
        }
    }
}
