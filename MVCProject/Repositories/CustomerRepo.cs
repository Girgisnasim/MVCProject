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

        public List<Ticket> GetAll()
        {
            return context.tickets.ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
