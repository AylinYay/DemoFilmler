using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoFilmler.DTOs
{
    public class FilmDto  // DTO: Data Transfer Object (Model) // Kullanıcıya ne gösterilecekse buradan ayar yapılır. Kullanıcıdan nasıl veri alınacaksa buradan yapılır.
    {
        #region Entity üzerinden kopyaladığımız özellikler

        [DisplayName("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        [DisplayName("Adı")]
        public string Adi { get; set; }  // = null!;

        [StringLength(4)]
        [DisplayName("Yapım Yılı")]
        public string YapimYili { get; set; }

        [Browsable(false)]
        public int? YonetmenId { get; set; }

        [Browsable(false)]
        public decimal? Gisesi { get; set; }
        #endregion




        #region Uygulamada gösterim ihtiyacı için kullanacağımız özellikler

        [DisplayName("Yönetmeni")]
        public string YonetmenAdiSoyadiGosterim { get; set; }

        [DisplayName("Gişesi")]
        public string GisesiGosterim { get; set; }

        [Browsable(false)]
        public string YonetmenDurumuGosterim { get; set; }

        [Browsable(false)]
        public string MaliyetiGosterim { get; set; }

        [Browsable(false)]
        public string KarZararGosterim { get; set; }

        [Browsable(false)]
        public string AciklamasiGosterim { get; set; }

        [Browsable(false)]
        public string TurleriGosterim { get; set; }
        #endregion       
    }
}
