using System.ComponentModel.DataAnnotations;

namespace DemoFilmler.Entities
{
    public class FilmDetay
    {
        [Key]  // Filmler db'inden çekmeyip elle oluşturulduğundan PK olduğunu belirtmek için [Key] attibute u kullanılmalı.
        public int FilmId { get; set; }

        public decimal Maliyeti { get; set; }

        public string Aciklamasi { get; set; }

        public Film Film { get; set; }
    }
}
