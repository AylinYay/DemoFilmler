using DemoFilmler.Contexts;
using DemoFilmler.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DemoFilmler
{
    public partial class FilmDetayForm : Form
    {
        FilmlerContext _db = new FilmlerContext();

        int _mevcutFilmId;

        public FilmDetayForm(int mevcutFilmId)
        {
            _mevcutFilmId = mevcutFilmId;
            InitializeComponent();
        }

        private void FilmDetayForm_Load(object sender, EventArgs e)
        {
            txtID.Text = _mevcutFilmId.ToString();
            Temizle();
            FilmDetayiniDoldur();
        }

        private void Temizle()
        {
            lAdi.Text = "";
            lGisesi.Text = "";
            lMaliyeti.Text = "";
            lYapimYili.Text = "";
            lAciklamasi.Text = "";
            lKarZarar.Text = "";
            lYonetmenAdiSoyadi.Text = "";
            lDurum.Text = "";
            lTurleri.Text = "";
        }

        private void bFilmDetayiniGetir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtID.Text, out _mevcutFilmId))
                {
                    MessageBox.Show("ID sayısal olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FilmDetayiniDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi! (" + ex.Message + " | " + ex.InnerException?.Message + ")", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilmDetayiniDoldur()
        {
            FilmDto mevcutFilm;

            IQueryable<FilmDto> filmQuery = _db.Filmler.Include(film => film.Yonetmen)
                .Include(film => film.FilmDetay)
                .Include(film => film.FilmTurleri)
                .ThenInclude(filmTur => filmTur.Tur) // many to many ilişkisi
                .Select(film => new FilmDto()
                {
                    Id = film.Id,
                    Adi = film.Adi,
                    YapimYili = film.YapimYili,

                    GisesiGosterim = film.Gisesi.HasValue ? film.Gisesi.Value.ToString("C2", new CultureInfo("tr-TR")) : "0",
                    YonetmenAdiSoyadiGosterim = film.Yonetmen.Adi + " " + film.Yonetmen.Soyadi,
                    YonetmenDurumuGosterim = !film.Yonetmen.EmekliMi.HasValue ? "" : (film.Yonetmen.EmekliMi.Value ? "Emekli" : "Çalışıyor"),    // YonetmenDurumu = film.Yonetmen.EmekliMi ?? false ? "Emekli" : "Çalışıyor"  
                    MaliyetiGosterim = film.FilmDetay.Maliyeti.ToString("C2", new CultureInfo("tr-TR")),
                    AciklamasiGosterim = film.FilmDetay.Aciklamasi,
                    KarZararGosterim = film.Gisesi.HasValue ? (film.Gisesi.Value - film.FilmDetay.Maliyeti).ToString("C2", new CultureInfo("tr-TR")) : "",
                    TurleriGosterim = string.Join("\r\n", film.FilmTurleri.Select(filmTur => filmTur.Tur.Adi))  // many to many ilişki olduğundan FilmTurleri'ndeki her bir elemanın adına .Select ile ulaşabiliriz.
                });
            mevcutFilm = filmQuery.SingleOrDefault(f => f.Id == _mevcutFilmId);

            if (mevcutFilm == null)
            {
                MessageBox.Show("Film bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lAdi.Text = mevcutFilm.Adi;
            lYapimYili.Text = mevcutFilm.YapimYili;

            lGisesi.Text = mevcutFilm.GisesiGosterim;
            lMaliyeti.Text = mevcutFilm.MaliyetiGosterim;
            lAciklamasi.Text = mevcutFilm.AciklamasiGosterim;
            lKarZarar.Text = mevcutFilm.KarZararGosterim;
            lYonetmenAdiSoyadi.Text = mevcutFilm.YonetmenAdiSoyadiGosterim;
            lDurum.Text = mevcutFilm.YonetmenDurumuGosterim;
            lTurleri.Text = mevcutFilm.TurleriGosterim;
        }
    }
}
