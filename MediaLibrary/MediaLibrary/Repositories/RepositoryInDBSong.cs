using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Song entities, inheriting from generic RepositoryInDb.
/// </summary>
public class RepositoryInDbSong : RepositoryInDb<Song>, IRepositorySong
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDbSong"/> class.
    /// </summary>
    /// <param name="context">The database context to be used for data operations.</param>
    public RepositoryInDbSong(ApplicationDbContext context) : base(context) { }
}
