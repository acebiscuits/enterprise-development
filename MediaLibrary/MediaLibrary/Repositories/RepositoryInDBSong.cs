using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Song entities, inheriting from generic RepositoryInDB.
/// </summary>
public class RepositoryInDBSong : RepositoryInDB<Song>, IRepositorySong
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDBSong"/> class.
    /// </summary>
    /// <param name="context">The database context to be used for data operations.</param>
    public RepositoryInDBSong(ApplicationDbContext context) : base(context) { }
}
