using MediaLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

public interface IAlbumService
{
    AlbumDto GetById(int id);
    IEnumerable<AlbumDto> GetAll();
    void Add(AlbumCreateDto albumCreateDto);
    void Update(AlbumDto albumDto);
    void Delete(int id);
}
