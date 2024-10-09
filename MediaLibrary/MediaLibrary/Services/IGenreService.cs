using MediaLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

public interface IGenreService
{
    GenreDto GetById(int id);
    IEnumerable<GenreDto> GetAll();
    void Add(GenreCreateDto genreCreateDto);
    void Update(GenreDto genreDto);
    void Delete(int id);
}
