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
                context.trips.Update(trip);
                context.SaveChanges();
                context.tickets.Add(ticket);
                context.SaveChanges();
            }
        }

        public Trip showTicket(int id)
        {
            Trip ticket = context.trips.SingleOrDefault(x => x.Id == id);
            return ticket;
        }

    }
}
