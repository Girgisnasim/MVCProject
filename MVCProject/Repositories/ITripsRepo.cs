using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface ITripsRepo
    {
        //Get All Trips By Loction
        public List<string> GetLoctions();
        //Get station
        public List<Trip> GetStation(string name1);
    }
}
