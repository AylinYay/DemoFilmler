using System.ComponentModel.DataAnnotations;

namespace DemoFilmler.Entities;

public class Film
{
    public int Id { get; set; }

    [Required]
    [StringLength(300)]
    public string Adi { get; set; }  // = null!;

    [StringLength(4)]
    public string YapimYili { get; set; }

    public int? YonetmenId { get; set; }

    public decimal? Gisesi { get; set; }

    public Yonetmen Yonetmen { get; set; }

    public List<FilmTur> FilmTurleri { get; set; } = new List<FilmTur>();

    public FilmDetay FilmDetay { get; set; }
}
