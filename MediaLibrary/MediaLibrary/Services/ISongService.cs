using MediaLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

public interface ISongService
{
    SongDto GetById(int id);
    IEnumerable<SongDto> GetAll();
    void Add(SongCreateDto song);
    void Update(SongDto song);
    void Delete(int id);
}
