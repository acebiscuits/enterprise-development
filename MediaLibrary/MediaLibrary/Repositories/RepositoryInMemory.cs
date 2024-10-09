using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

public class RepositoryInMemory<T> : IRepositoryInMemory<T> where T : class, IEntity
{
    private List<T> _entities = new();
    private int _currentId = 0;

    public T GetById(int id)
    {
        return _entities.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<T>GetAll() => _entities;
    public void Add(T entity)
    {
        _currentId += 1;
        entity.Id = _currentId;
        _entities.Add(entity);
    }

    virtual public void Update(T entity)
    {
    }

    public void Delete(int id)
    {
        if(GetById(id) != null)
        {
            _entities.Remove(GetById(id));
        }
    }
}
