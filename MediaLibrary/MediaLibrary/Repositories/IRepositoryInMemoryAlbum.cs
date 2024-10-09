using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

public interface IRepositoryInMemoryAlbum : IRepositoryInMemory<Album>
{
}
