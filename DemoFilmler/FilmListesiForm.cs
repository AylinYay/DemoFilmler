using DemoFilmler.Contexts;
using DemoFilmler.DTOs;
using DemoFilmler.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DemoFilmler
{
    public partial class FilmListesiForm : Form
    {
        FilmlerContext _db = new FilmlerContext();

        public FilmListesiForm()
        {
            InitializeComponent();
        }

        private void FilmlerForm_Load(object sender, EventArgs e)
        {
            try
            {
                lFilmSayisi.Text = "";
                FilmListesiniDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ýþlem sýrasýnda hata meydana geldi! (" + ex.Message + " | " + ex.InnerException?.Message + ")", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilmListesiniDoldur()
        {
            IQueryable<FilmDto> filmQuery = _db.Filmler.Include(film => film.Yonetmen)
                .OrderBy(film => film.Yonetmen.Adi)
                .ThenBy(film => film.Yonetmen.Soyadi)
                .ThenBy(film => film.Adi)
                .Select(film => new FilmDto()
                {
                    Id = film.Id,
                    Adi = film.Adi,
                    YapimYili = film.YapimYili,

                    GisesiGosterim = film.Gisesi.HasValue ? film.Gisesi.Value.ToString("C2", new CultureInfo("tr-TR")) : "",
                    YonetmenAdiSoyadiGosterim = film.Yonetmen.Adi + " " + film.Yonetmen.Soyadi
                });

            List<FilmDto> filmListesi = filmQuery.ToList();
            dgvFilmler.DataSource = filmListesi;
            dgvFilmler.ClearSelection();

            lFilmSayisi.Text = filmListesi.Count == 0 ? "Film bulunamadý." : filmListesi.Count + " film bulundu";

            FilmListesiSutunlariniDuzenle();
        }

        private void FilmListesiSutunlariniDuzenle()
        {
            dgvFilmler.Columns["Id"].Width = 50;
            dgvFilmler.Columns["Adi"].Width = 200;
            dgvFilmler.Columns["YonetmenAdiSoyadiGosterim"].Width = 190;
            dgvFilmler.Columns["Yapimyili"].Width = 100;
            dgvFilmler.Columns["GisesiGosterim"].Width = 190;
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FilmListesiniDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ýþlem sýrasýnda hata meydana geldi! (" + ex.Message + " | " + ex.InnerException?.Message + ")", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bDetay_Click(object sender, EventArgs e)
        {
            if (dgvFilmler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Listeden film seçilmelidir!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int mevcutFilmId = Convert.ToInt32(dgvFilmler.SelectedRows[0].Cells["Id"].Value);
                FilmDetayForm filmDetayForm = new FilmDetayForm(mevcutFilmId);
                filmDetayForm.Show();
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilmEkleForm form = new FilmEkleForm();
            form.Show();
        }

        private void bDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvFilmler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Listeden film seçilmelidir!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int mevcutFilmId = Convert.ToInt32(dgvFilmler.SelectedRows[0].Cells["Id"].Value);
                Form form = new FilmDuzenleForm(mevcutFilmId);
                form.Show();
            }
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            if (dgvFilmler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Listeden film seçilmelidir!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Filmi silmek istediðinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int mevcutFilmId = Convert.ToInt32(dgvFilmler.SelectedRows[0].Cells["Id"].Value);
                    Sil(mevcutFilmId);
                    MessageBox.Show("Filmi baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void Sil(int id)
        {
            Film mevcutFilm = _db.Filmler.Include(film => film.FilmDetay).Include(film => film.FilmTurleri).SingleOrDefault(film => film.Id == id);
            _db.FilmDetaylari.Remove(mevcutFilm.FilmDetay);
            _db.FilmTurler.RemoveRange(mevcutFilm.FilmTurleri);
            _db.Filmler.Remove(mevcutFilm);
            _db.SaveChanges();
        }
    }
}