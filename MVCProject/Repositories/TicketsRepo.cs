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

        public List<Trip> GetAllTrips()
        {
            throw new NotImplementedException();
        }

        public int Add(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}
