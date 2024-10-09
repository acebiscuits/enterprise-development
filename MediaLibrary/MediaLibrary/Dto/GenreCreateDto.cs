using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Dto;

public class GenreCreateDto
{
    [Required]
    public string Title { get; set; }
    public List<int> ArtistIds { get; set; } = new();
}
