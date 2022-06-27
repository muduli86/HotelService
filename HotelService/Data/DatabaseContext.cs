using Microsoft.EntityFrameworkCore;

namespace HotelService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Country>().HasData(
                new Country {
                    Id = 1,
                    Name = "India",
                    ShortName = "IN"
                },
                new Country {
                    Id = 2,
                    Name = "United Kingdom",
                    ShortName = "UK"
                },
                new Country {
                    Id = 3,
                    Name = "Canada",
                    ShortName = "CN"
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel {
                    Id = 1,
                    Name = "Hotel1",
                    Address = "Novo add",
                    CountryId = 1,
                    Rating = "4.5"
                },
                new Hotel {
                    Id = 2,
                    Name = "Hotel2",
                    Address = "Hotel 2 add",
                    CountryId = 2,
                    Rating = "4.5"
                },
                new Hotel {
                    Id = 3,
                    Name = "Hotel3",
                    Address = "Hotel3 add",
                    CountryId = 1,
                    Rating = "4.5"
                }
            );
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}