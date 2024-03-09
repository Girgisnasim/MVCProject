using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Numerics;

namespace MVCProject.Models
{
    public class BookContext:DbContext
    {

        public BookContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

          => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookDb;Integrated Security=True;TrustServerCertificate=True");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasKey("CustomerId", "TripId");
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<Plan> plan { get; set; }
        public DbSet<Ticket> tickets { get; set; }


    }
}
