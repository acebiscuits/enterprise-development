using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository for managing Song entities.
/// Inherits from the generic Repository class.
/// </summary>
public class RepositoryInMemorySong : RepositoryInMemory<Song>, IRepositorySong
{
    /// <inheritdoc />
    public RepositoryInMemorySong(List<Song> initData) : base(initData) { }
    /// <inheritdoc />
    public override void Update(Song song)
    {
        var existingSong = GetById(song.Id);
        if (existingSong != null)
        {
            existingSong.Duration = song.Duration;
            existingSong.Name = song.Name;
            existingSong.AlbumName = song.AlbumName;
            existingSong.NumberInAlbum = song.NumberInAlbum;
        }
    }
}
