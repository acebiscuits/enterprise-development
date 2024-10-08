using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Dto;

internal class GenreDto
{
    public required int Id { get; set; }
    public string Title { get; set; }
    public List<int> ArtistIds { get; set; }
}
