using System.ComponentModel.DataAnnotations;

namespace DemoFilmler.Entities;

public class Yonetmen
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Adi { get; set; } //= null!;

    [Required]
    [StringLength(50)]
    public string Soyadi { get; set; } //= null!;

    public DateTime? DogumTarihi { get; set; }

    public bool? EmekliMi { get; set; }

    public List<Film> Filmler { get; set; } = new List<Film>();
}
