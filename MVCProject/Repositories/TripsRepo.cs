using MVCProject.Models;

namespace MVCProject.Repositories
{
    public class TripsRepo:ITripsRepo
    {
        private BookContext context;

        public TripsRepo(BookContext context)
        {
            this.context = context;
        }

        public List<Trip> AllTrips()
        {
            return context.trips.ToList();
        }

        public List<string> GetLoctions()
        {
            List<string> Station = context.trips.Select(t => t.Location).Distinct().ToList();
            return Station;
        }

        public List<Trip> GetStation(string name1)
        {
           List<Trip> trips=context.trips.Where(t=>t.Location==name1).ToList();
            return trips;
        }
    }
}
