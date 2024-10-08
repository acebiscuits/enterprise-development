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
    private int id;

    public T GetById(int id)
    {
        return _entities.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<T>GetAll() => _entities;
    public void Add(T entity)
    {
        id += 1;
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
