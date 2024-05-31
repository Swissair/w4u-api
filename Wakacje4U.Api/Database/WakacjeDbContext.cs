using Microsoft.EntityFrameworkCore;

namespace Wakacje4U.Api.Database;

public class WakacjeDbContext : DbContext
{
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Wakacje4UDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            var annaCustomer = new Customer{ Id=1, FirstName = "Anna", LastName="Klemp"};
            modelBuilder.Entity<Customer>().HasData(annaCustomer);
            

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation{Id=1, CustomerId=1, StartDate = new DateTime(2024, 6, 22),
                EndDate=new DateTime(2024, 7, 7)}
            );

             base.OnModelCreating(modelBuilder);
        }
}