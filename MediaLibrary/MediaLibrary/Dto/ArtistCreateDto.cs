using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Dto;

public class ArtistCreateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public List<int> AlbumIds { get; set; } = new();
    public List<int> GenreIds { get; set; } = new();
}
