using MediaLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

public interface IArtistService
{
    ArtistDto GetById(int id);
    IEnumerable<ArtistDto> GetAll();
    void Add(ArtistCreateDto artistDto);
    void Delete(int id);
    void Update(ArtistDto artistDto);
}
