using System.ComponentModel.DataAnnotations;

namespace DemoFilmler.DTOs
{
    public class YonetmenDto
    {
        #region Entity üzerinden kopyaladığımız özellikler
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; } //= null!;

        [Required]
        [StringLength(50)]
        public string Soyadi { get; set; } //= null!;

        public DateTime? DogumTarihi { get; set; }

        public bool? EmekliMi { get; set; }
        #endregion


        #region Uygulamada gösterim ihtiyacı için kullanacağımız özellikler
        public string AdiSoyadiGosterim { get; set; }
        #endregion
    }
}
