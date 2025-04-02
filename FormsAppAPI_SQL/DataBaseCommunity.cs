using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MauiAppAPI")]

namespace StudentAPI.DataBase
{
    internal class Community : DbContext
    {
        private const int BaseId = 11;

        public DbSet<Person> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }


        public Community() { Database.EnsureCreated(); /* Tworzy bazę, jeśli nie istnieje*/ }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            string projectDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
            string dbPath = Path.Combine(projectDirectory, "Univ.db");
            // options.UseSqlite("Data Source=Univ.db"); // Ścieżka do pliku bazy danych
            options.UseSqlite($"Data Source={dbPath}");
        }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Address>().HasKey(a => a.AddressId);
            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);

            modelBuilder.Entity<Address>().OwnsOne(a => a.geo).HasData(
                new {AddressId = BaseId + 0, lat = "52.2298", lng = "21.0122"},
                new {AddressId = BaseId + 1, lat = "52.2298", lng = "21.0122"},
                new {AddressId = BaseId + 2, lat = "51.11",   lng = "17.0222"}
            );
            
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithMany()
                .HasForeignKey(p => p.AddressId)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Company)
                .WithMany()
                .HasForeignKey(p => p.CompanyId)
                .IsRequired();

            modelBuilder.Entity<Address>().HasData(
                new {
                    AddressId = BaseId+ 0, 
                    street = "PolskaStreet", suite = "4", city = "Warszawa", zipcode = "00-001"},
                new {
                    AddressId = BaseId+ 1,
                    street = "WarszawskaStreet", suite = "3", city = "Warszawa", zipcode = "00-001"},
                new {
                    AddressId = BaseId+ 2,
                    street = "WroclawskaStreet", suite = "34", city = "Wrocław", zipcode = "50-001"}
            );

            modelBuilder.Entity<Company>().HasData(
                new Company {CompanyId = BaseId+ 0, name = "JakowSoftDev"},
                new Company {CompanyId = BaseId+ 1, name = "DotNetSoft"}
            );

            modelBuilder.Entity<Person>().HasData(
                new Person {
                    Id = BaseId+ 0,
                    Name = "Jan Kowalski",
                    Username = "JaKow",
                    Email = "Jakow@example.com",
                    AddressId = BaseId+ 0,
                    CompanyId = BaseId+ 0
                },
                new Person {
                    Id = BaseId+ 1,
                    Name = "Adam Kowalski",
                    Username = "AdaKow",
                    Email = "Adakow@example.com",
                    AddressId = BaseId+ 1,
                    CompanyId = BaseId+ 0
                },
                new Person {
                    Id = BaseId+ 2,
                    Name = "Beata Nowak",
                    Username = "NowaBeata",
                    Email = "NowaBeata@example.com",
                    AddressId = BaseId+ 2,
                    CompanyId = BaseId+ 1
                }
            );
        }
    }
}