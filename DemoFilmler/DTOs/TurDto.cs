using System.ComponentModel.DataAnnotations;

namespace DemoFilmler.DTOs
{
    public class TurDto  // Entity üzerinden kopyaladığımız özellikler
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Adi { get; set; }
    }
}
