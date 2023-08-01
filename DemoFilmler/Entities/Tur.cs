using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoFilmler.Entities;

public class Tur
{
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Adi { get; set; } //= null!;

    public List<FilmTur> FilmTurleri { get; set; } = new List<FilmTur>();
}
