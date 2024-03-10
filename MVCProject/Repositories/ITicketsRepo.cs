using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface ITicketsRepo
    {
        // to show  ticket 
        public Trip showTicket(int id);
        //Add ticket
        public void Add (Ticket ticket);
        //Get By Id
        public List<Ticket> GetTicketsOfUser (int id );
    }
}
