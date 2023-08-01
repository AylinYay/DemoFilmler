using DemoFilmler.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoFilmler.Contexts;

public partial class FilmlerContext : DbContext
{   

    public virtual DbSet<Film> Filmler { get; set; }

    public virtual DbSet<Tur> Turler { get; set; }

    public virtual DbSet<Yonetmen> Yonetmenler { get; set; }

    public virtual DbSet<FilmTur> FilmTurler { get; set; }

    public virtual DbSet<FilmDetay> FilmDetaylari { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AYLIN\\SQLAYLIN;Database=Filmler;trusted_connection=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<FilmTur>().HasKey("FilmId", "TurId");
        modelBuilder.Entity<FilmTur>().HasKey(filmTur => new {filmTur.FilmId, filmTur.TurId});

        //modelBuilder.Entity<Film>().ToTable("Film");
        modelBuilder.Entity<Film>().ToTable(nameof(Film));
        modelBuilder.Entity<Tur>().ToTable(nameof(Tur));
        modelBuilder.Entity<Yonetmen>().ToTable(nameof(Yonetmen));
        modelBuilder.Entity<FilmTur>().ToTable(nameof(FilmTur));
        modelBuilder.Entity<FilmDetay>().ToTable(nameof(FilmDetay));
    }
}
