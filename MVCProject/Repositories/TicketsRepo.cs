using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCProject.Models;

namespace MVCProject.Repositories
{
    public class TicketsRepo : ITicketsRepo
    {
        private BookContext context;

        public TicketsRepo(BookContext context)
        {
            this.context = context;
        }

        public void Add(Ticket ticket)
        {
            Trip trip=context.trips.SingleOrDefault(t=>t.Id==ticket.TripId);
            if (trip!=null)
            {
                trip.Available_Seats = trip.Available_Seats - ticket.Quentity;
                if (trip.Available_Seats == 0)
                {
                    trip.Status = "not avalable";
                }
                else
                {
                    trip.Status = "avalable";
                }
                context.trips.Update(trip);
                context.SaveChanges();
                context.tickets.Add(ticket);
                context.SaveChanges();
            }

        }

        public List<Ticket> GetTicketsOfUser(int id)
        {
           List<Ticket> tickets = context.tickets.Include(t => t.Trip).Where(t => t.CustomerId == id).ToList();
            return tickets;
        }

        public Trip showTicket(int id)
        {
            Trip ticket = context.trips.SingleOrDefault(x => x.Id == id);
            return ticket;
        }

    }
}
