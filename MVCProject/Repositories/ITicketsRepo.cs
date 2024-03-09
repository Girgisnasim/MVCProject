using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface ITicketsRepo
    {
        // to show all of tickets available
        public List<Trip> GetAllTrips();
        //Add ticket
        public int Add (Trip trip);
    }
}
