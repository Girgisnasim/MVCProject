using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface ITicketsRepo
    {
        // to show  ticket 
        public Trip showTicket(int id);
        //Add ticket
        public int Add (Trip trip);
    }
}
