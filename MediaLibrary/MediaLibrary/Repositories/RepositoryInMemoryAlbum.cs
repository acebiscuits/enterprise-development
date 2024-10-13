using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository for managing Album entities.
/// Inherits from the generic RepositoryInMemory class.
/// </summary>
public class RepositoryInMemoryAlbum : RepositoryInMemory<Album>, IRepositoryAlbum
{
    /// <inheritdoc />
    public RepositoryInMemoryAlbum(List<Album> initData) : base(initData) { }
    /// <inheritdoc />
    override public void Update(Album album)
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
