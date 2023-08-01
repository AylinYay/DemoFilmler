using DemoFilmler.Contexts;
using DemoFilmler.DTOs;
using DemoFilmler.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DemoFilmler
{
    public partial class FilmDuzenleForm : Form
    {
        int _mevcutFilmId;

        FilmlerContext _db = new FilmlerContext();

        public FilmDuzenleForm(int mevcutFilmId)
        {
            _mevcutFilmId = mevcutFilmId;
            InitializeComponent();
        }

        private void FilmDuzenleForm_Load(object sender, EventArgs e)
        {
            lMesaj.Text = "";
            YapimYiliListesiniDoldur();
            YonetmenListesiniDoldur();
            TurListesiniDoldur();
            FilmDetayiniDoldur();
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

        private void FilmDetayiniDoldur()
        {
            Film mevcutFilm = _db.Filmler.Include(film => film.Yonetmen).Include(film => film.FilmDetay).Include(film => film.FilmTurleri).SingleOrDefault(film => film.Id == _mevcutFilmId);

            if (mevcutFilm is null)
            {
                lMesaj.Text = "Film bulunamadı!";
                return;
            }
            tbAdi.Text = mevcutFilm.Adi;
            ddlYapimYili.Text = mevcutFilm.YapimYili;
            tbGisesi.Text = mevcutFilm.Gisesi?.ToString("N2", new CultureInfo("tr-TR"));
            tbMaliyeti.Text = mevcutFilm.FilmDetay?.Maliyeti.ToString("N2", new CultureInfo("tr-TR"));
            tbAciklamasi.Text = mevcutFilm.FilmDetay?.Aciklamasi;

            ddlYonetmenAdiSoyadi.SelectedValue = mevcutFilm.YonetmenId ?? -1;

            if (mevcutFilm.FilmTurleri != null && mevcutFilm.FilmTurleri.Count > 0)
            {
                for (int i = 0; i < mevcutFilm.FilmTurleri.Count; i++)
                {
                    for (int j = 0; j < lbTurler.Items.Count; j++)
                    {
                        if ((lbTurler.Items[j] as TurDto).Id == mevcutFilm.FilmTurleri[i].TurId)
                        {
                            lbTurler.SetSelected(j, true);
                            break;
                        }
                    }
                }
            }
        }

        private Film FilmOlustur()
        {
            Film mevcutFilm = _db.Filmler.Find(_mevcutFilmId);

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

            decimal? gisesi = null;
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
                if (!decimal.TryParse(tbMaliyeti.Text, NumberStyles.Any, new CultureInfo("tr-TR"), out donusturulecekMaliyet)) // maliyet sayıya dönüştürülemiyorsa
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

            if (_db.Filmler.Any(film => film.Adi.ToLower() == adi.ToLower() && film.Id != _mevcutFilmId))
            {
                lMesaj.Text = "Girdiğiniz ada sahip film bulunmaktadır!";
                return null;
            }


            mevcutFilm.Adi = adi;
            mevcutFilm.Gisesi = gisesi;
            mevcutFilm.YapimYili = yapimYili;
            mevcutFilm.YonetmenId = yonetmenId;

            mevcutFilm.FilmDetay = new FilmDetay()
            {
                Maliyeti = maliyeti,
                Aciklamasi = aciklamasi
            };

            mevcutFilm.FilmTurleri = turIdleri.Select(turId => new FilmTur()
            {
                TurId = turId
            }).ToList();

            return mevcutFilm;
        }

        private void bGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                lMesaj.Text = "";
                Film mevcutFilm = FilmOlustur();
                if (mevcutFilm is not null)
                {
                    Guncelle(mevcutFilm);
                    lMesaj.Text = "Film başarıyla güncellendi";
                }
            }
            catch (Exception ex)
            {
                lMesaj.Text = "İşlem sırasında hata meydana geldi! (" + ex.Message + " | " + ex.InnerException?.Message + ")";
            }
        }

        private void Guncelle(Film film)
        {
            _db.Filmler.Update(film);
            _db.SaveChanges();
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
    }
}
