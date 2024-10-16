using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository for managing Song entities.
/// Inherits from the generic Repository class.
/// </summary>
public class RepositoryInMemorySong : RepositoryInMemory<Song>, IRepositorySong
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInMemorySong"/> class with initial data.
    /// </summary>
    /// <param name="initData">The initial list of songs for the repository.</param>
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
