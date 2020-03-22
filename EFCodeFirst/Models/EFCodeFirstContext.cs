using Microsoft.EntityFrameworkCore;
using ModelDesignFirst;

namespace EFCodeFirst.Models
{
    class EFCodeFirstContext : DbContext
    {

        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<AlbumArtist> AlbumsArtists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=EFCodeFirst;Trusted_Connection=True;");
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            modelBuilder.Entity<Customer>()
               .Property(b => b.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();
            modelBuilder.Entity<Order>()
               .Property(b => b.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();
            modelBuilder.Entity<Artist>()
               .Property(b => b.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();
            modelBuilder.Entity<Album>()
               .Property(b => b.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<AlbumArtist>()
                .HasKey(x => new { x.AlbumId, x.ArtistId });
            modelBuilder.Entity<AlbumArtist>()
                .HasOne<Album>()
                .WithMany()
                .HasForeignKey(x => x.AlbumId);
            modelBuilder.Entity<AlbumArtist>()
                .HasOne<Artist>()
                .WithMany()
                .HasForeignKey(x => x.ArtistId);

            //to do


        }
        #endregion
    }
}
