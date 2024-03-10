using MVCProject.Models;

namespace MVCProject.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private BookContext context;

        public CustomerRepo(BookContext context)
        {
            this.context = context;
        }

        public List<Trip> GetAll()
        {
            return context.trips.ToList();
        }


    }
}
