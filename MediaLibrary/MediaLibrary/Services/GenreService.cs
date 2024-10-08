using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

internal class GenreService : IGenreService
{
    private readonly IRepositoryInMemoryGenre _repositoryInMemoryGenre;

    public GenreDto GetById(int id)
    {
        var genre = _repositoryInMemoryGenre.GetById(id);
        if(genre == null)
        {
            return null;
        }
        return new GenreDto
        {
            Id = genre.Id,
            ArtistIds = genre.ArtistIds,
            Title = genre.Title
        };
    }
    public IEnumerable<GenreDto> GetAll()
    {
        var genres = _repositoryInMemoryGenre.GetAll();
        return genres.Select(genre => new GenreDto
        {
            Id = genre.Id,
            ArtistIds = genre.ArtistIds,
            Title = genre.Title
        });
    }
    public void Add(GenreCreateDto genreCreateDto)
    {
        _repositoryInMemoryGenre.Add(new Genre
        {
            ArtistIds = genreCreateDto.ArtistIds,
            Title = genreCreateDto.Title
        });
    }
    public void Update(GenreDto genreDto)
    {
        var genre = _repositoryInMemoryGenre.GetById(genreDto.Id);
        if(genre != null)
        {
            genre.ArtistIds = genreDto.ArtistIds ?? genre.ArtistIds;
            genre.Title = genreDto.Title ?? genre.Title;
        }
    }
    public void Delete(int id)
    {
        _repositoryInMemoryGenre.Delete(id);
    }
}
