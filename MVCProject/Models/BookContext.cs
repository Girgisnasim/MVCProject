using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Numerics;

namespace MVCProject.Models
{
    public class BookContext:IdentityDbContext<ApplicationUser>
    {

        public BookContext(){}
        public BookContext(DbContextOptions options) : base(options) { }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //  => optionsBuilder.UseSqlServer("Data Source=DESKTOP-84KCKJI\\SQLEXPRESS;Initial Catalog=BookDb;Integrated Security=True;TrustServerCertificate=True");



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ticket>().HasKey("CustomerId", "TripId");
            base.OnModelCreating(modelBuilder);
        }
       

     
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<Plan> plan { get; set; }
        public DbSet<Ticket> tickets { get; set; }


    }
}
