using DemoFilmler.Contexts;
using DemoFilmler.DTOs;
using DemoFilmler.Entities;
using System.Data;
using System.Globalization;

namespace DemoFilmler
{
    public partial class FilmEkleForm : Form
    {
        FilmlerContext _db = new FilmlerContext();

        public FilmEkleForm()
        {
            InitializeComponent();
        }

        private void FilmEkleForm_Load(object sender, EventArgs e)
        {
            try
            {
                lMesaj.Text = "";
                YapimYiliListesiniDoldur();
                YonetmenListesiniDoldur();
                TurListesiniDoldur();
            }
            catch (Exception ex)
            {
                lMesaj.Text = "İşlem sırasında hata meydana geldi! (" + ex.Message + " | " + ex.InnerException?.Message + ")";
            }
        }

        private void YapimYiliListesiniDoldur()
        {
            ddlYapimYili.Items.Add("-- Seçiniz --");
            for (int yil = DateTime.Now.Year + 5; yil >= 1900; yil--)
            {
                ddlYapimYili.Items.Add(yil.ToString());
            }
            ddlYapimYili.SelectedIndex = 0;
        }

        private void YonetmenListesiniDoldur()
        {
            List<YonetmenDto> yonetmenListesi;

            IQueryable<YonetmenDto> yonetmenQuery = _db.Yonetmenler.OrderBy(yonetmen => yonetmen.Adi)
                .ThenBy(yonetmen => yonetmen.Soyadi)
                .Select(yonetmen => new YonetmenDto()
                {
                    Id = yonetmen.Id,

                    AdiSoyadiGosterim = yonetmen.Adi + " " + yonetmen.Soyadi
                });

            yonetmenListesi = yonetmenQuery.ToList();

            yonetmenListesi.Insert(0, new YonetmenDto()
            {
                Id = -1,
                AdiSoyadiGosterim = ""
            });

            ddlYonetmenAdiSoyadi.DataSource = yonetmenListesi;
            ddlYonetmenAdiSoyadi.ValueMember = "Id";
            ddlYonetmenAdiSoyadi.DisplayMember = "AdiSoyadiGosterim";
        }

        private void TurListesiniDoldur()
        {
            IQueryable<TurDto> turQuery = _db.Turler.Select(tur => new TurDto()
            {
                Id = tur.Id,
                Adi = tur.Adi
            });

            turQuery = turQuery.OrderBy(tur => tur.Adi);

            lbTurler.DataSource = turQuery.ToList();
            lbTurler.ValueMember = "Id";
            lbTurler.DisplayMember = "Adi";
            lbTurler.ClearSelected();
        }

        private void bTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            tbAdi.Text = "";
            ddlYapimYili.SelectedIndex = 0;
            tbGisesi.Text = "";
            tbMaliyeti.Text = "";
            ddlYonetmenAdiSoyadi.SelectedIndex = 0;
            lbTurler.ClearSelected();
            lMesaj.Text = "";
            tbAciklamasi.Text = "";

        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            try
            {
                lMesaj.Text = "";
                Film yeniFilm = FilmOlustur();
                if(yeniFilm is not null)
                {
                    Ekle(yeniFilm);
                    lMesaj.Text = "Film başarıyla eklendi";
                }
            }
            catch (Exception ex)
            {
                lMesaj.Text = "İşlem sırasında hata meydana geldi! (" + ex.Message + " | " + ex.InnerException?.Message + ")";
            }
        }

        private void Ekle(Film film)
        {
            _db.Filmler.Add(film);
            _db.SaveChanges();
        }

        private Film FilmOlustur()
        {
            Film yeniFilm;

            string adi = tbAdi.Text.Trim();
            if (string.IsNullOrWhiteSpace(adi))  // adı girilmediyse
            {
                lMesaj.Text = "Adı zorunludur!";
                return null;
            }

            string yapimYili;
            if (ddlYapimYili.SelectedIndex == 0) // -- Seçiniz --
            {
                lMesaj.Text = "Yapım yılı seçilmelidir!";
                return null;
            }
            yapimYili = ddlYapimYili.Text;

            int? yonetmenId = null;
            if (Convert.ToInt32(ddlYonetmenAdiSoyadi.SelectedValue) != -1)
                yonetmenId = Convert.ToInt32(ddlYonetmenAdiSoyadi.SelectedValue);

            decimal ? gisesi = null;
            if (!string.IsNullOrWhiteSpace(tbGisesi.Text))  // gişesi girildiyse
            {
                decimal donusturulecekGise;
                if (!decimal.TryParse(tbGisesi.Text, NumberStyles.Any, new CultureInfo("tr-TR"), out donusturulecekGise)) // gişe sayıya dönüştürülemiyorsa
                {
                    lMesaj.Text = "Gişe sayısa lolmalıdır!";
                    return null;
                }
                gisesi = donusturulecekGise;
            }

            decimal maliyeti = 0; 
            if (!string.IsNullOrWhiteSpace(tbMaliyeti.Text)) // maliyet girildiyse
            {
                decimal donusturulecekMaliyet;
                if(!decimal.TryParse(tbMaliyeti.Text, NumberStyles.Any, new CultureInfo("tr-TR"), out donusturulecekMaliyet)) // maliyet sayıya dönüştürülemiyorsa
                {
                    lMesaj.Text = "Maliyeti zorunludur!";
                    return null;
                }
                maliyeti = donusturulecekMaliyet;
            }
            else
            {
                lMesaj.Text = "Maliyet zorunludur!";
                return null;
            }

            string aciklamasi = tbAciklamasi.Text;

            List<int> turIdleri = new List<int>();
            foreach (var selectedItem in lbTurler.SelectedItems)
            {
                turIdleri.Add((selectedItem as TurDto).Id);
            }

            //Film mevcutFilm = _db.Filmler.SingleOrDefault(film => film.Adi.ToLower() == adi.ToLower());
            //if (mevcutFilm is not null)
            //{
            //    lMesaj.Text = "Girdiğiniz ada sahip film bulunmaktadır!";
            //    return null;
            //}
            
            if(_db.Filmler.Any(film => film.Adi.ToLower() == adi.ToLower()))
            {
                lMesaj.Text = "Girdiğiniz ada sahip film bulunmaktadır!";
                return null;
            }

            yeniFilm = new Film()
            {
                Adi = adi,
                Gisesi = gisesi,
                YapimYili = yapimYili,
                YonetmenId = yonetmenId,

                FilmDetay = new FilmDetay()
                {
                    Maliyeti = maliyeti,
                    Aciklamasi = aciklamasi
                },

                FilmTurleri = turIdleri.Select(turId => new FilmTur()
                {
                    TurId = turId
                }).ToList()
            };

            return yeniFilm;
            
        }
    }
}
