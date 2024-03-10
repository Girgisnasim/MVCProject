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

        public int Add(Trip trip)
        {
            throw new NotImplementedException();
        }

        public Trip showTicket(int id)
        {
            Trip ticket = context.trips.SingleOrDefault(x => x.Id == id);
            return ticket;
        }
    }
}
