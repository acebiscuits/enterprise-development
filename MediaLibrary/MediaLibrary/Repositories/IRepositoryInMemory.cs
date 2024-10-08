using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

public interface IRepositoryInMemory<T> where T : class, IEntity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    T GetById(int id);
    IEnumerable<T> GetAll();
}
