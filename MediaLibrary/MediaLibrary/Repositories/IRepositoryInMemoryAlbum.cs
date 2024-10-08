using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

internal interface IRepositoryInMemoryAlbum : IRepositoryInMemory<Album>
{
}
