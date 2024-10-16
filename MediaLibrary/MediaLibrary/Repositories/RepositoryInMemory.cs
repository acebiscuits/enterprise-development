using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Generic in-memory repository implementation for managing entities of type T.
/// </summary>
/// <typeparam name="T">The type of the entity being managed, must implement IEntity interface.</typeparam>
public class RepositoryInMemory<T> : IRepository<T> where T : class, IEntity
{
    /// <summary>
    /// The collection of entities stored in memory.
    /// </summary>
    private List<T> _entities = [];

    /// <summary>
    /// The current ID for assigning unique identifiers to entities.
    /// </summary>
    private int _currentId;
    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    public RepositoryInMemory(List<T> entities)
    {
        _entities = entities;
    }
    /// <inheritdoc />
    public T? GetById(int id)
    {
        return _entities.FirstOrDefault(a => a.Id == id);
    }

    /// <inheritdoc />
    public IEnumerable<T> GetAll() => _entities;

    /// <inheritdoc />
    public void Add(T entity)
    {
        _currentId += 1;
        entity.Id = _currentId;
        _entities.Add(entity);
    }

    /// <inheritdoc />
    public virtual void Update(T entity)
    {
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _entities.Remove(entity);
        }
    }
}
