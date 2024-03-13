using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
namespace MVCProject.Repositories
{
    public class AdminRepo:IAdminRepo
    {
        BookContext Context;

        public AdminRepo(BookContext _context)
        {
            Context = _context;
        }
        public List<Trip> Getall()
        {
            return Context.trips.Include(e=>e.Employee).ToList();

        }
       public Trip Get(int id)
        {
            return Context.trips.SingleOrDefault(x => x.Id == id);
        }
        public void Add(Trip trip)
        {
            Context.trips.Add(trip);
            Context.SaveChanges();
        }

        public  void Update(Trip trip) {
          
            Context.trips.Update(trip);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Trip trip = Context.trips.SingleOrDefault(t => t.Id == id);
            Context.trips.Remove(trip);
            Context.SaveChanges();

        }
    }
}
